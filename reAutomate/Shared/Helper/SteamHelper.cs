using Gameloop.Vdf;
using Microsoft.Win32; // Required for RegisterKey and Registry
using System;
using System.Collections.Generic;
using System.IO;

namespace reAutomate.Shared.Helper
{
    public static class SteamHelper
    {
        private static string SteamBase;

        private static readonly List<string> Libraries = new List<string>();
        public static readonly List<Steam.Game> Games = new List<Steam.Game>();

        private static readonly List<int> BlacklistedSteamIds = new List<int>()
        {
            250820, // SteamVR
            228980 // Steamworks Common Redistributables
        };

        static SteamHelper()
        {
            GetInstallPath();
            GetLibraries();
            GetGames();
        }

        private static void GetInstallPath()
        {
            using RegistryKey key = Registry.LocalMachine
                .OpenSubKey("Software")
                .OpenSubKey("WOW6432Node")
                .OpenSubKey("Valve")
                .OpenSubKey("Steam");

            if (key is null)
                SteamBase = string.Empty;
            else
                SteamBase = $"{key.GetValue("InstallPath")}";
        }

        private static void GetLibraries()
        {
            string steamBase = IOHelper.GetDirectoryFullName(SteamBase);
            string librariesVdf = IOHelper.GetFileFullName(Path.Combine(steamBase, "steamapps", "libraryfolders.vdf"));

            try
            {
                dynamic rawLibraries = VdfConvert.Deserialize(File.ReadAllText(librariesVdf));

                for (int i = 0; i < 99; i++)
                    Libraries.Add(rawLibraries.Value[$"{i}"].Value);
            }
            catch (Exception e)
            {
                // Todo: Logging
                // Most likely, we run into the exception that the current index is out if bound
            }
        }

        public static void GetGames()
        {
            foreach (string library in Libraries)
            {
                DirectoryInfo steamLibrary = new DirectoryInfo(library);
                DirectoryInfo steamApps = new DirectoryInfo(Path.Combine(steamLibrary.FullName, "steamapps"));

                if (!steamLibrary.Exists)
                    continue;

                foreach (FileInfo file in steamApps.EnumerateFiles("appmanifest_*.acf", SearchOption.TopDirectoryOnly))
                {
                    dynamic gameVdf = VdfConvert.Deserialize(File.ReadAllText(file.FullName));

                    string gameDirectory = Path.Combine(steamApps.FullName, "common", gameVdf.Value["installdir"].Value);
                    string gameName = gameVdf.Value["name"].Value;
                    int gameId = int.Parse(gameVdf.Value["appid"].Value);

                    if (BlacklistedSteamIds.Contains(gameId))
                        continue;

                    Steam.Game foundGame = new Steam.Game()
                    {
                        Id = gameId,
                        Location = gameDirectory,
                        Name = gameName
                    };

                    Games.Add(foundGame);
                };
            }
        }
    }
}