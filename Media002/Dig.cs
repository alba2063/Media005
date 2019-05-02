using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using Microsoft.Win32;
using SongsDB;

namespace Media002
{
    class Dig
    {
        SDBApplicationClass SDB = new SDBApplicationClass();

        public Song CurrentSong()
        {
            Song info = new Song();
            //SDB.ShutdownAfterDisconnect = false;

            int songIndex = SDB.Player.CurrentSongIndex;

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

            //int i = 0;
            //int k = 0;

            while (songIndex < allSongCount)
            {
                if (songIndex == allSongCount - 1)
                {
                    //songIndex = 0; //Start from first song

                    info.Artist = "";
                    info.Genre = "";

                    break;
                }
                else
                {
                    info = GetSongInfo(songIndex);
                    var genre = info.Genre.ToLowerInvariant();

                    if (!genre.Equals("tango") && !genre.Equals("vals") && !genre.Equals("milonga"))
                    {
                        songIndex += 1;

                        info = GetSongInfo(songIndex);

                        break;
                    }

                    songIndex += 1;
                }
            }

            return info;
        }

        private Song GetSongInfo(int songIndex)
        {
            Song info = new Song();

            var song = SDB.Player.CurrentSongList.Item[songIndex];
            var songID = song.ID;

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

            // Singer
            if (song.AlbumName == null)
            {
                info.Album = "Instrumental";
            }
            else
            {
                info.Album = song.AlbumName.ToString();
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

            if (songIndex < SDB.Player.CurrentSongList.Count - 1)
            {
                if (songIndex >= 0)
                {
                    curGenre = SDB.Player.CurrentPlaylist.Item[songIndex].Genre;

                    tot += 1;
                    cur += 1;

                    if (songIndex >= 1)
                    {
                        if (SDB.Player.CurrentPlaylist.Item[songIndex - 1].Genre.Equals(curGenre))
                        {
                            tot += 1;
                            cur += 1;

                            if (songIndex >= 2)
                            {
                                if (SDB.Player.CurrentPlaylist.Item[songIndex - 2].Genre.Equals(curGenre))
                                {
                                    tot += 1;
                                    cur += 1;

                                    if (songIndex >= 3)
                                    {
                                        if (SDB.Player.CurrentPlaylist.Item[songIndex - 3].Genre.Equals(curGenre))
                                        {
                                            tot += 1;
                                            cur += 1;

                                            if (songIndex >= 4)
                                            {
                                                if (SDB.Player.CurrentPlaylist.Item[songIndex - 4].Genre.Equals(curGenre))
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


                    if (SDB.Player.CurrentPlaylist.Item[songIndex + 1].Genre.Equals(curGenre))
                    {
                        tot += 1;

                        if (songIndex + 2 < SDB.Player.CurrentSongList.Count)
                        {
                            if (SDB.Player.CurrentPlaylist.Item[songIndex + 2].Genre.Equals(curGenre))
                            {
                                tot += 1;

                                if (songIndex + 3 < SDB.Player.CurrentSongList.Count)
                                {
                                    if (SDB.Player.CurrentPlaylist.Item[songIndex + 3].Genre.Equals(curGenre))
                                    {
                                        tot += 1;

                                        if (songIndex + 4 < SDB.Player.CurrentSongList.Count)
                                        {
                                            if (SDB.Player.CurrentPlaylist.Item[songIndex + 4].Genre.Equals(curGenre))
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
            else
            {
                
                
            }

            songC[0] = cur;
            songC[1] = tot;
            return songC;
        }
    }
}
