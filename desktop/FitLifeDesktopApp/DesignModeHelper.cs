using System.ComponentModel;

namespace FitLifeDesktopApp;

public static class DesignModeHelper
{
    public static bool IsInDesignMode => LicenseManager.UsageMode == LicenseUsageMode.Designtime
        || System.Diagnostics.Process.GetCurrentProcess().ProcessName.Contains("devenv", StringComparison.OrdinalIgnoreCase);
}
