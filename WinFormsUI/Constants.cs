using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CarEngine
{
    /// <summary>
    ///  A class to keep UI-related constants
    /// </summary>
    public static class Constants
    {
        // Integers
        public static readonly int AdsInBrowsePage = 15;
        public static readonly int AdsInLikedAdsPage = 15;
        public static readonly int AdsInUploadedAdsPage = 15;

        // Colors
        public static readonly Color ActiveSidebarButtonColor = Color.AntiqueWhite;
        public static readonly Color ActiveSidebarButtonTextColor = Color.Black;
        public static readonly Color InactiveSidebarButtonColor = Color.Transparent;
        public static readonly Color InactiveSidebarButtonTextColor = Color.Transparent;
        public static readonly Color SelectedAdColor = Color.Aquamarine;
        public static readonly Color NormalAdColor = Color.FloralWhite;
    }
}
