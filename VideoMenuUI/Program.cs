using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using VideoMenuBLL;
using VideoMenuBLL.BusinessObjects;
using VideoMenuDAL.Entities;


namespace VideoMenuUI
{
    class Program
    {
      static BLLFacade bllFacade = new BLLFacade();

        private static string[] genreItems =
        {
            "Action",
            "Kids",
            "Sci-Fi"
        };

        static void Main(string[] args)
        {
            var gen1 = new GenreBO()
            {
                Name = "Action"
            };
            gen1 = bllFacade.GenreService.Create(gen1);

            var vid1 = new VideoBO()
            {
                Name = "The Hobbit",
                Genre = gen1
            };
            
            bllFacade.VideoService.Create(vid1);
            
            

            string[] menuItems =
            {
                "Show all vieos",
                "Add a video",
                "Edit a video",
                "Delete a video",
                "Search for a video",
                "Exit"
            };
            

            var selection = ShowMenu(menuItems);

            while (selection != 6)
            {
                switch (selection)
                {
                    case 1:
                        Console.Clear();
                        ListAllVideos();
                        Console.WriteLine($"All videos are shown\n");
                        break;
                    case 2:
                        Console.Clear();
                        AddVideos();
                        Console.WriteLine("Added a video\n");
                        break;
                    case 3:
                        Console.Clear();
                        EditVideo();
                        Console.WriteLine("Edited a video\n");
                        break;
                    case 4:
                        Console.Clear();
                        DeleteVideo();
                        Console.WriteLine("Deleted a video\n");
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine(FindVideoById().Name);
                        Console.WriteLine("Searched for a video\n");
                        break;
                    default:
                        Console.Clear();
                        break;

                }
                selection = ShowMenu(menuItems);
            }
            Console.WriteLine("Bye bye!");
            Console.ReadLine();
        }

        private static void DeleteVideo()
        {
            var videoFound = FindVideoById();
            if (videoFound != null)
            {
                bllFacade.VideoService.Delete(videoFound.Id);
            }

            var response = videoFound == null ? "Video not found" : "Video was deleted";
            Console.WriteLine(response);
        }

        private static VideoBO FindVideoById()
        {
            Console.WriteLine("Insert video Id: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Please insert a number");
            }
            
            return bllFacade.VideoService.Get(id);
        }

        public static void EditVideo()
        {
            var video = FindVideoById();
            if (video != null)
            {
                Console.WriteLine("Name: ");
                video.Name = Console.ReadLine();
                
                bllFacade.VideoService.Update(video);
            }
            else
            {
                Console.WriteLine("Customer not Found");
            }
            
        }

        public static void AddVideos()
        {
            Console.WriteLine("Name: ");
            var name = Console.ReadLine();
            

            bllFacade.VideoService.Create(new VideoBO()
            {
                Name = name,
                
            });
            Console.Clear();
        }

        public static void ListAllVideos()
        {
            foreach (var video in bllFacade.VideoService.GetAll())
            {
                Console.WriteLine($"Name: {video.Name}    Genre: {video.Genre}    ID: {video.Id}");
            }
            Console.WriteLine("\n");
        }

        private static int ShowMenu(string[] menuItems)
        {
            Console.WriteLine("Select what you want to do:\n");

            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine($"{(i + 1)}: {menuItems[i]}");
            }

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection)
                   || selection < 1
                   || selection > 6)
            {
                Console.WriteLine("Please select a number between 1-6\n");
            }
            return selection;
        }

        private static int ShowGenre(string[] genreItems)
        {
            Console.WriteLine("Select Genre: ");
            for (int i = 0; i < genreItems.Length; i++)
            {
                Console.WriteLine($"{(i + 1)}: {genreItems[i]}");
            }

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection)
                   || selection < 1
                   || selection > 3)
            {
                Console.WriteLine("Please select a number between 1-3\n");
            }
            return selection;
        }
    }
}