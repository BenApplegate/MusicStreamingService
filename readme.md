# Music Streaming Service

This serves as my attempt to make a home-grown self-hosted music streaming service
I have been generally dissatisfied with most music streaming services, so I figured I would try my hand at making my own.

The current plan is to make a backend in C# with a Mongo database to store info about the music and serve info and media to the client.
Then I plan to start with a React web interface to interact with the backend that will serve as a data management tool and streaming service.

# Planned features
 - Multiple users able to manage separate media libraries
 - Simple management of media upload including metadata management
 - Playback of media files of different formats, hopefully mp3, flac, wav to start
 - Playlist creation and sharing
 - Auto DJ based off of tags/mood settings
 - Rating system including options for multiple ratings per song, or ratings with categories for better AutoDJ algorithmic selection

# Silly future ideas
 - I would love to have the option to connect the backend to a discord bot to allow for media playback with friends over discord

# Build Information

## Backend
The backend is found in `Server/` to run it, `cd` into `Server/` and run 
``` bash
dotnet run
```

## Frontend Client
At this stage in development the client is nonexistent but info for building/running will come as soon as client takes shape