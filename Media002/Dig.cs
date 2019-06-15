using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using Microsoft.Win32;
using SongsDB;

namespace MediaInfo
{
    class Dig
    {
        readonly SDBApplicationClass SDB = new SDBApplicationClass();
        Int16 albumSource;      //indicator of a source for Album label

        public Song CurrentSong(Int16 albumSource)
        {
            Song info = new Song();
            //SDB.ShutdownAfterDisconnect = false;

            int songIndex = SDB.Player.CurrentSongIndex;
            this.albumSource = albumSource;

            info = GetSongInfo(songIndex);
            return info;
        }

        public Song NextTanda()
        {
            Song info = new Song();
            //SDB.ShutdownAfterDisconnect = false;

            //Next song index calculation
            int allSongCount = SDB.Player.CurrentSongList.Count;
            int songIndex = SDB.Player.CurrentSongIndex;

            //Scan playlist to find cartina (genre is not tango, vals or milonga)
            while (songIndex < allSongCount)
            {
                if (songIndex == allSongCount - 1) //Last song in playlist
                {
                    info.Artist = "";
                    info.Genre = "";

                    break;
                }
                else
                {
                    //read current song 
                    info = GetSongInfo(songIndex);
                    var genre = info.Genre.ToLowerInvariant();

                    //If current song is cartina
                    if (!genre.Equals("tango") && !genre.Equals("vals") && !genre.Equals("milonga"))
                    {
                        //read next song
                        songIndex += 1;
                        info = GetSongInfo(songIndex);

                        break;
                    }

                    //Move to the next song in a playlist
                    songIndex += 1; 
                }
            }

            return info;
        }

        //Load song info from Media Monkey API
        private Song GetSongInfo(int songIndex)
        {
            Song info = new Song();

            var song = SDB.Player.CurrentSongList.Item[songIndex];
            var songID = song.ID;
            string source = "";  //Info of Album label

            // Title
            if (song.Title == null)
            {
                info.Title = "";
            }
            else
            {
                info.Title = song.Title.ToString();
            }

            // Artist
            if (song.ArtistName == null)
            {
                info.Artist = "";
            }
            else
            {
                info.Artist = (song.ArtistName.ToString());
            }

            // Album/Singer source depends on UISettings
            if (albumSource == 0)
            {
                source = song.AlbumName;
            }
            else if (albumSource == 1)
            {
                source = song.Conductor;
            }

            if (source == string.Empty)
            {
                info.Album = "";
            }
            else
            {
                info.Album = source;
            }

            // Genre
            if (song.Genre == null)
            {
                info.Genre = "";
            }
            else
            {
                info.Genre = song.Genre.ToString();
            }

            // Year
            if (song.Year == 0)
            {
                info.Year = "";
            }
            else
            {
                info.Year = song.Year.ToString();
            }

            //var art = song.AlbumArt.Item[0].Image;
            info.Index = "Index: " + songIndex.ToString();
            info.SongID = "Song ID: " + songID.ToString();

            return info;
        }


        public string GetSongArt()
        {
            string orq = SDB.Player.CurrentSong.ArtistName;

            if (orq != null)
            {

            }
            else
            {
                return "Null";
            }

            return "Null";
        }

        public int[] SongCount()
        {
            //
            int[] songC = new int[2] { 0, 0 };
            string curGenre;
            int tot = 0;    //Total songs in tanda
            int cur = 0;    //Current song in tanda
            //
            int songIndex = SDB.Player.CurrentSongIndex;


            if (songIndex >= 0)
            {
                curGenre = SDB.Player.CurrentPlaylist.Item[songIndex].Genre;

                if (curGenre != null)
                {
                    tot += 1;
                    cur += 1;

                    if (songIndex >= 1)
                    {
                        if (string.IsNullOrEmpty(SDB.Player.CurrentPlaylist.Item[songIndex - 1].Genre))
                        {
                        }
                        else if (SDB.Player.CurrentPlaylist.Item[songIndex - 1].Genre.Equals(curGenre))
                        {
                            tot += 1;
                            cur += 1;

                            if (songIndex >= 2)
                            {
                                if (string.IsNullOrEmpty(SDB.Player.CurrentPlaylist.Item[songIndex - 2].Genre))
                                {
                                }
                                else if (SDB.Player.CurrentPlaylist.Item[songIndex - 2].Genre.Equals(curGenre))
                                {
                                    tot += 1;
                                    cur += 1;

                                    if (songIndex >= 3)
                                    {
                                        if (string.IsNullOrEmpty(SDB.Player.CurrentPlaylist.Item[songIndex - 3].Genre))
                                        {
                                        }
                                        else if (SDB.Player.CurrentPlaylist.Item[songIndex - 3].Genre.Equals(curGenre))
                                        {
                                            tot += 1;
                                            cur += 1;

                                            if (songIndex >= 4)
                                            {
                                                if (string.IsNullOrEmpty(SDB.Player.CurrentPlaylist.Item[songIndex - 4].Genre))
                                                {
                                                }
                                                else if (SDB.Player.CurrentPlaylist.Item[songIndex - 4].Genre.Equals(curGenre))
                                                {
                                                    tot += 1;
                                                    cur += 1;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (songIndex < SDB.Player.CurrentSongList.Count - 1)
                    {
                        if (string.IsNullOrEmpty(SDB.Player.CurrentPlaylist.Item[songIndex + 1].Genre))
                        {
                        }
                        else if (SDB.Player.CurrentPlaylist.Item[songIndex + 1].Genre.Equals(curGenre))
                        {
                            tot += 1;

                            if (songIndex + 2 < SDB.Player.CurrentSongList.Count)
                            {
                                if (string.IsNullOrEmpty(SDB.Player.CurrentPlaylist.Item[songIndex + 2].Genre))
                                {
                                }
                                else if (SDB.Player.CurrentPlaylist.Item[songIndex + 2].Genre.Equals(curGenre))
                                {
                                    tot += 1;

                                    if (songIndex + 3 < SDB.Player.CurrentSongList.Count)
                                    {
                                        if (string.IsNullOrEmpty(SDB.Player.CurrentPlaylist.Item[songIndex + 3].Genre))
                                        {
                                        }
                                        else if (SDB.Player.CurrentPlaylist.Item[songIndex + 3].Genre.Equals(curGenre))
                                        {
                                            tot += 1;

                                            if (songIndex + 4 < SDB.Player.CurrentSongList.Count)
                                            {
                                                if (string.IsNullOrEmpty(SDB.Player.CurrentPlaylist.Item[songIndex + 4].Genre))
                                                {
                                                }
                                                else if (SDB.Player.CurrentPlaylist.Item[songIndex + 4].Genre.Equals(curGenre))
                                                {
                                                    tot += 1;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
            }

            songC[0] = cur;
            songC[1] = tot;

            return songC;
        }
    }
}
