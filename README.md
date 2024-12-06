# Real-Time Chat Application
Test task for Reenbit

This application is a real-time chat built using Blazor WebAssembly for the frontend and ASP.NET Core with SignalR for real-time messaging on the backend. It allows users to chat in real-time and analyze message sentiments using a sentiment analysis service.

# Features
User Nickname Registration and Change: Users can set and change their nickname.

Real-Time Chat: Users can send messages that are instantly delivered to other users.

Sentiment Analysis: Each message is analyzed for sentiment and displayed with an emoji representing the sentiment (positive, negative, or neutral).

Chat History: The last 50 messages are stored in the database and can be loaded by all users.

SignalR Integration: Used for real-time communication.

# Project Structure
Backend: ASP.NET Core API with SignalR for real-time messaging.

Frontend: Blazor WebAssembly for the chat interface and message handling.

Database: Stores chat history.

Azure: Deployed to Azure for hosting both frontend and backend components.

# Requirements
.NET 8.0 or higher.

Azure Subscription for hosting the application.

SQL Server or Azure SQL Database for storing chat data.
