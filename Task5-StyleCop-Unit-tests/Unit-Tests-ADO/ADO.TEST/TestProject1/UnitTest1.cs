using System;
using System.Collections.Generic;
using Xunit;
using Npgsql;
using ADOConsoleApp; 

namespace ADOConsoleApp.Tests
{
    public class FetchFunctionsTests
    {
        private const string connectionString = "Host=localhost;Username=postgres;Password=your_password;Database=bePresent";

        
        [Fact]
        public void FetchUsers_ShouldReturnData()
        {
            
            var users = Program.FetchUsers();

           
            Assert.NotNull(users);
            Assert.NotEmpty(users);
            Assert.Contains(users, u => u["username"].ToString() == "User1"); 
        }

        
        [Fact]
        public void FetchGiftBoards_ShouldReturnData()
        {
            
            var boards = Program.FetchGiftBoards();

            
            Assert.NotNull(boards);
            Assert.NotEmpty(boards);
            Assert.Contains(boards, b => b["name"].ToString() == "Board1"); 
        }

       
        [Fact]
        public void FetchGifts_ShouldReturnData()
        {
           
            var gifts = Program.FetchGifts();

           
            Assert.NotNull(gifts);
            Assert.NotEmpty(gifts);
            Assert.Contains(gifts, g => g["name"].ToString() == "Gift1"); 
        }

        
        [Fact]
        public void FetchGiftReservations_ShouldReturnData()
        {
            
            var reservations = Program.FetchGiftReservations();

            
            Assert.NotNull(reservations);
            Assert.NotEmpty(reservations);
            Assert.True(reservations.Count > 0);
        }

        
        [Fact]
        public void FetchActionLogs_ShouldReturnData()
        {
           
            var logs = Program.FetchActionLogs();

           
            Assert.NotNull(logs);
            Assert.NotEmpty(logs);
            Assert.Contains(logs, l => l["action"].ToString().StartsWith("Action")); 
        }

        
        [Fact]
        public void FetchEmailConfirmations_ShouldReturnData()
        {
            
            var confirmations = Program.FetchEmailConfirmations();

           
            Assert.NotNull(confirmations);
            Assert.NotEmpty(confirmations);
            Assert.All(confirmations, c => Assert.NotNull(c["confirmation_token"]));
        }
    }
}
