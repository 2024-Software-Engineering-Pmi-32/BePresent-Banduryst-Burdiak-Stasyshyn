using Npgsql;
using System;

namespace ADOConsoleApp
{
    class Program
    {
        static string connectionString = "Host=localhost;Username=postgres;Password=1234;Database=bePresent";

        static void Main(string[] args)
        {
            
            FillUsers();
            FillGiftBoards();
            FillGifts();
            FillGiftReservations();
            FillActionLogs();
            FillEmailConfirmations();


            FetchUsers();
            FetchGiftBoards();
            FetchGifts();
            FetchGiftReservations();
            FetchActionLogs();
            FetchEmailConfirmations();

            Console.ReadKey();
        }

     
        static void FillUsers()
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                for (int i = 1; i <= 30; i++)
                {
                    string query = "INSERT INTO users (username, email, password) VALUES (@username, @email, @password)";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("username", "User" + i);
                        cmd.Parameters.AddWithValue("email", "user" + i + "@example.com");
                        cmd.Parameters.AddWithValue("password", "Password" + i);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        static void FillGiftBoards()
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                for (int i = 1; i <= 10; i++)
                {
                    string name = "Board" + i;
                    int userId = (i % 30) + 1;

                    string query = "INSERT INTO boards (user_id, name, celebration_date, collaborators, access_level, description) VALUES (@user_id, @name, @celebration_date, @collaborators, @access_level, @description)";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("user_id", userId);
                        cmd.Parameters.AddWithValue("name", name);
                        cmd.Parameters.AddWithValue("celebration_date", DateTime.Now.AddDays(i * 10));
                        cmd.Parameters.AddWithValue("collaborators", new[] { 1, 2, 3 });
                        cmd.Parameters.AddWithValue("access_level", i % 2 == 0 ? "public" : "private");
                        cmd.Parameters.AddWithValue("description", "Description of board " + i);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        static void FillGifts()
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                for (int i = 1; i <= 30; i++)
                {
                    string name = "Gift" + i;
                    int boardId = (i % 10) + 1;
                   

                    string query = "INSERT INTO gifts (board_id, name, description, link, image_url, is_reserved) VALUES (@board_id, @name, @description, @link, @image_url, @is_reserved)";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("board_id", boardId);
                        cmd.Parameters.AddWithValue("name", name);
                        cmd.Parameters.AddWithValue("description", "Description of gift " + i);
                        cmd.Parameters.AddWithValue("link", $"http://example.com/gift{i}");
                        cmd.Parameters.AddWithValue("image_url", $"http://example.com/gift{i}.jpg");
                        cmd.Parameters.AddWithValue("is_reserved", i % 2 == 0);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        static void FillGiftReservations()
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                for (int i = 1; i <= 15; i++)
                {
                    int giftId = (i % 30) + 1;
                    int userId = (i % 30) + 1;
                   
                    string query = "INSERT INTO giftReservations (gift_id, user_id) VALUES (@gift_id, @user_id)";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("gift_id", giftId);
                        cmd.Parameters.AddWithValue("user_id", userId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }


        static void FillActionLogs()
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                for (int i = 1; i <= 30; i++)
                {
                    int userId = (i % 30) + 1;
                    string action = "Action " + i;

                    string query = "INSERT INTO actionlogs (user_id, action) VALUES (@user_id, @action)";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("user_id", userId);
                        cmd.Parameters.AddWithValue("action", action);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }


        static void FillEmailConfirmations()
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                for (int i = 1; i <= 30; i++)
                {
                    int userId = (i % 30) + 1;
                    string token = Guid.NewGuid().ToString();

                    string query = "INSERT INTO emailconfirmations (user_id, confirmation_token, expires_at) VALUES (@user_id, @confirmation_token, @expires_at)";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("user_id", userId);
                        cmd.Parameters.AddWithValue("confirmation_token", token);
                        cmd.Parameters.AddWithValue("expires_at", DateTime.Now.AddHours(24));
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }


        static void FetchUsers()
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM users";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        Console.WriteLine("users:");
                        while (reader.Read())
                        {
                            Console.WriteLine($"ID: {reader["user_id"]}, Username: {reader["username"]}, Email: {reader["email"]}");
                        }
                    }
                }
            }
        }

        static void FetchGiftBoards()
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM boards";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        Console.WriteLine("GiftBoards:");
                        while (reader.Read())
                        {
                            Console.WriteLine($"Board ID: {reader["board_id"]}, Name: {reader["name"]}, User ID: {reader["user_id"]}");
                        }
                    }
                }
            }
        }

        static void FetchGifts()
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM gifts";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        Console.WriteLine("Gifts:");
                        while (reader.Read())
                        {
                            Console.WriteLine($"Gift ID: {reader["gift_id"]}, Name: {reader["name"]}, Board ID: {reader["board_id"]}");
                        }
                    }
                }
            }
        }

        static void FetchGiftReservations()
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM giftreservations";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        Console.WriteLine("GiftReservations:");
                        while (reader.Read())
                        {
                            Console.WriteLine($"Reservation ID: {reader["reservation_id"]}, Gift ID: {reader["gift_id"]}, User ID: {reader["user_id"]}");
                        }
                    }
                }
            }
        }

        static void FetchActionLogs()
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM actionlogs";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        Console.WriteLine("ActionLogs:");
                        while (reader.Read())
                        {
                            Console.WriteLine($"Log ID: {reader["log_id"]}, User ID: {reader["user_id"]}, Action: {reader["action"]}");
                        }
                    }
                }
            }
        }

        static void FetchEmailConfirmations()
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM emailconfirmations";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        Console.WriteLine("EmailConfirmations:");
                        while (reader.Read())
                        {
                            Console.WriteLine($"Confirmation ID: {reader["confirmation_id"]}, User ID: {reader["user_id"]}, Token: {reader["confirmation_token"]}");
                        }
                    }
                }
            }
        }
    }
}
