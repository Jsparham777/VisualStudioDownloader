﻿namespace VisualStudioDownloader.Animations
{
    /// <summary>
    /// Styles of page animations for appearing/disappearing.
    /// </summary>
    public enum PageAnimation
    {
        /// <summary>
        /// No page animation.
        /// </summary>
        None = 0,

        /// <summary>
        /// The page slides in and fades in from the right.
        /// </summary>
        SlideAndFadeInFromRight = 1,

        /// <summary>
        /// The page slides out and fades out to the left.
        /// </summary>
        SlideAndFadeOutToLeft = 2,

        /// <summary>
        /// The page slides in and fades in from the right.
        /// </summary>
        SlideAndFadeInFromLeft = 3,

        /// <summary>
        /// The page slides in and fades in from the right.
        /// </summary>
        SlideAndFadeOutToRight = 4,
    }
}
