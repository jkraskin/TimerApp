﻿// <copyright file="AboutPage.xaml.cs" company="Theta Rex, Inc.">
//    Copyright © 2021 - Theta Rex, Inc.  All Rights Reserved.
// </copyright>
// <author>Joshua Kraskin</author>
namespace TimerApp.Views
{
    using TimerApp.ViewModels;
    using Xamarin.Forms;

    /// <summary>
    /// AboutPage class inheriting from ContentPage.
    /// </summary>
    public partial class AboutPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AboutPage"/> class.
        /// </summary>
        /// <param name="aboutViewModel">Aboutviewmodel.</param>
        public AboutPage(AboutViewModel aboutViewModel)
        {
            this.InitializeComponent();
            this.BindingContext = aboutViewModel;
        }
    }
}