﻿using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace VisualStudioDownloader.Animations
{
    /// <summary>
    /// Helpers to animate pages in specific ways.
    /// </summary>
    public static class PageAnimations
    {
        /// <summary>
        /// Slides a page in from the right.
        /// </summary>
        /// <param name="page">The page to animate.</param>
        /// <param name="seconds">The animation duration.</param>
        /// <returns>An awaitable <see cref="Task"/>.</returns>
        public static async Task SlideAndFadeInFromRightAsync(this Page page, float seconds)
        {
            //Create the storyboard
            var sb = new Storyboard();

            //Add slide from right animation
            sb.AddSlideFromRight(seconds, page.WindowWidth);

            //Add fade in animation
            sb.AddFadeIn(seconds);

            //Start animating
            sb.Begin(page);

            //Make the page visible
            page.Visibility = Visibility.Visible;

            //Wait for the animation to finish
            await Task.Delay((int)(seconds * 1000));            
        }

        /// <summary>
        /// Slides a page in from the left.
        /// </summary>
        /// <param name="page">The page to animate.</param>
        /// <param name="seconds">The animation duration.</param>
        /// <returns>An awaitable <see cref="Task"/>.</returns>
        public static async Task SlideAndFadeInFromLeftAsync(this Page page, float seconds)
        {
            //Create the storyboard
            var sb = new Storyboard();

            //Add slide from right animation
            sb.AddSlideFromLeft(seconds, page.WindowWidth);

            //Add fade in animation
            sb.AddFadeIn(seconds);

            //Start animating
            sb.Begin(page);

            //Make the page visible
            page.Visibility = Visibility.Visible;

            //Wait for the animation to finish
            await Task.Delay((int)(seconds * 1000));
        }

        /// <summary>
        /// Slides a page out to the left.
        /// </summary>
        /// <param name="page">The page to animate.</param>
        /// <param name="seconds">The animation duration.</param>
        /// <returns>An awaitable <see cref="Task"/>.</returns>
        public static async Task SlideAndFadeOutToLeftAsync(this Page page, float seconds)
        {
            //Create the storyboard
            var sb = new Storyboard();

            //Add slide to left animation
            sb.AddSlideToLeft(seconds, page.WindowWidth);

            //Add fade out animation
            sb.AddFadeOut(seconds);

            //Start animating
            sb.Begin(page);

            //Make the page visible
            page.Visibility = Visibility.Visible;

            //Wait for the animation to finish
            await Task.Delay((int)(seconds * 1000));
        }

        /// <summary>
        /// Slides a page out to the right.
        /// </summary>
        /// <param name="page">The page to animate.</param>
        /// <param name="seconds">The animation duration.</param>
        /// <returns>An awaitable <see cref="Task"/>.</returns>
        public static async Task SlideAndFadeOutToRightAsync(this Page page, float seconds)
        {
            //Create the storyboard
            var sb = new Storyboard();

            //Add slide to right animation
            sb.AddSlideToRight(seconds, page.WindowWidth);

            //Add fade out animation
            sb.AddFadeOut(seconds);

            //Start animating
            sb.Begin(page);

            //Make the page visible
            page.Visibility = Visibility.Visible;

            //Wait for the animation to finish
            await Task.Delay((int)(seconds * 1000));
        }
    }
}
