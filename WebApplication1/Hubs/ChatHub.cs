using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using RealTimeChat.Services;
using RealTimeChat.Data;
using Shared;
using Microsoft.EntityFrameworkCore;

namespace RealTimeChat.Hubs
{
    public class ChatHub : Hub
    {
        private readonly ChatAppDbContext dbContext;
        private readonly TextAnalyticsService textAnalyticsService;

        public ChatHub(ChatAppDbContext dbContext, TextAnalyticsService textAnalyticsService)
        {
            this.dbContext = dbContext;
            this.textAnalyticsService = textAnalyticsService;
        }

        public async Task AnalyzeAndSendMessage(string user, string message)
        {
            try
            {
                var sentiment = textAnalyticsService.AnalyzeSentiment(message);

                var chatMessage = new ChatMessage
                {
                    UserName = user,
                    Message = message,
                    Sentiment = sentiment,
                    CreatedAt = DateTime.UtcNow
                };

                dbContext.ChatMessages.Add(chatMessage);
                await dbContext.SaveChangesAsync();

                await Clients.All.SendAsync("ReceiveMessageWithSentiment", user, message, sentiment);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AnalyzeAndSendMessage: {ex.Message}");
            }
        }

        public async Task LoadChatHistory()
        {
            try
            {
                var messages = dbContext.ChatMessages
                .OrderByDescending(m => m.CreatedAt)
                .Take(50)
                .ToListAsync();

            await Clients.Caller.SendAsync("ReceiveChatHistory", messages);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in LoadChatHistory: {ex.Message}");
            }
        }
    }
}
