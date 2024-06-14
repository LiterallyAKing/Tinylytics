# Setting up Tinylytics

## Download the latest plugin

Go to releases and download the latest version, a .unitypackage file.

## Import the package into your project

In Unity, right click in the assets area and go to "Import Package > Import Custom Package" and import all the contents.

# Configuring your GoogleSheet database
This will show you how to set up a google sheet to act as your "database" to send event data to.

## Setting up the sheet

1. Navigate to this template sheet- [Tinylytics Data Destination Template](https://docs.google.com/spreadsheets/d/1afYRzPYwN3HHg_G63SF9lM1i2gaFDpsbTZCkur6cVnk "Tinylytics Data Destination Template")

2. Make a copy, name it whatever you’d like (and you can rename it whenever you want later too).
IMG HERE OF MAKING A COPY

In your new copy, go to Extensions > AppsScript

This will open a new tab, a project named Tinylytics_Instance, with a single script called PostGetHandling.gs
