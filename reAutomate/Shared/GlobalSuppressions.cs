// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "Pretty sure Registery Entries are supported on Windows", Scope = "member", Target = "~M:reAutomate.Shared.Helper.SteamHelper.GetInstallPath")]
[assembly: SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "Not being used in the Client", Scope = "member", Target = "~M:reAutomate.Shared.Helper.ProcessHelper.#ctor(System.Diagnostics.Process)")]
[assembly: SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "Not being used in the Client", Scope = "member", Target = "~M:reAutomate.Shared.Helper.ProcessHelper.Create(System.String,System.String)~reAutomate.Shared.Helper.ProcessHelper")]
[assembly: SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "Not being used in the Client", Scope = "member", Target = "~M:reAutomate.Shared.Helper.ProcessHelper.RunAsync~System.Threading.Tasks.Task{System.Boolean}")]
[assembly: SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "Not being used in the Client", Scope = "member", Target = "~M:reAutomate.Shared.Helper.ProcessHelper.Cancel")]
[assembly: SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "Not being used in the Client", Scope = "member", Target = "~M:reAutomate.Shared.Helper.ProcessHelper.HandleProcessExit(System.Object,System.EventArgs)")]