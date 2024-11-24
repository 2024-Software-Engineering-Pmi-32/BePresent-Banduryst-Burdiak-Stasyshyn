namespace ADOConsoleApp
{
    using Npgsql;
    using System;


    public class Program
    {
        static string connectionString = "Host=localhost;Username=postgres;Password=password;Database=bePresent";


        public static void FillUsers()
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

        public static void FillGiftBoards()
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

        public static void FillGifts()
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

        public static void FillGiftReservations()
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


        public static void FillActionLogs()
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


        public static void FillEmailConfirmations()
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

        public static List<Dictionary<string, object>> FetchUsers()
        {
            var users = new List<Dictionary<string, object>>();

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM users";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var user = new Dictionary<string, object>
                    {
                        { "user_id", reader["user_id"] },
                        { "username", reader["username"] },
                        { "email", reader["email"] }
                    };
                            users.Add(user);
                        }
                    }
                }
            }

            return users; 
        }

        public static List<Dictionary<string, object>> FetchGiftBoards()
        {
            var boards = new List<Dictionary<string, object>>();

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM boards";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var board = new Dictionary<string, object>
                    {
                        { "board_id", reader["board_id"] },
                        { "name", reader["name"] },
                        { "user_id", reader["user_id"] }
                    };
                            boards.Add(board);
                        }
                    }
                }
            }

            return boards;
        }

        public static List<Dictionary<string, object>> FetchGifts()
        {
            var gifts = new List<Dictionary<string, object>>();

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM gifts";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var gift = new Dictionary<string, object>
                    {
                        { "gift_id", reader["gift_id"] },
                        { "name", reader["name"] },
                        { "board_id", reader["board_id"] }
                    };
                            gifts.Add(gift);
                        }
                    }
                }
            }

            return gifts;
        }

        public static List<Dictionary<string, object>> FetchGiftReservations()
        {
            var reservations = new List<Dictionary<string, object>>();

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM giftreservations";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var reservation = new Dictionary<string, object>
                    {
                        { "reservation_id", reader["reservation_id"] },
                        { "gift_id", reader["gift_id"] },
                        { "user_id", reader["user_id"] }
                    };
                            reservations.Add(reservation);
                        }
                    }
                }
            }

            return reservations;
        }

        public static List<Dictionary<string, object>> FetchActionLogs()
        {
            var logs = new List<Dictionary<string, object>>();

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM actionlogs";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var log = new Dictionary<string, object>
                    {
                        { "log_id", reader["log_id"] },
                        { "user_id", reader["user_id"] },
                        { "action", reader["action"] }
                    };
                            logs.Add(log);
                        }
                    }
                }
            }

            return logs;
        }

        public static List<Dictionary<string, object>> FetchEmailConfirmations()
        {
            var confirmations = new List<Dictionary<string, object>>();

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM emailconfirmations";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var confirmation = new Dictionary<string, object>
                    {
                        { "confirmation_id", reader["confirmation_id"] },
                        { "user_id", reader["user_id"] },
                        { "confirmation_token", reader["confirmation_token"] }
                    };
                            confirmations.Add(confirmation);
                        }
                    }
                }
            }

            return confirmations;
        }
    }
}

