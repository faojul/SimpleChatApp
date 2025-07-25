# 🗨️ Real-Time WebSocket Chat with .NET 9 (Clean Architecture + Razor Pages)

A real-time, extensible chat application built using **.NET 9**, leveraging **Clean Architecture**, **Razor Pages with MVC pattern**, and **WebSocket** for real-time communication.

This project showcases scalable backend design and now includes Docker support, along with future integration plans for AI/ML agents, JWT, RSA encryption, SignalR, and unit tests.

---

## 🚀 Features

- ✅ Real-time **public and private** chat using **WebSockets**
- ✅ Clean Architecture (Domain, Application, Infrastructure, UI)
- ✅ Built on **.NET 9**, **Razor Pages**, **MVC pattern**
- ✅ Client registration via `/ws?clientId=xyz`
- ✅ Message routing: public or private via `@clientId`
- 🐳 Docker support for easy deployment

---

## 🤖 AI/ML Agent (Planned)

A built-in AI agent (e.g., `@Bot`) will:

- Automatically respond to specific queries (`@Bot what is the weather?`)
- Use local ML models or external LLM APIs
- Handle NLP and intent detection
- Integrate with external APIs (e.g., weather, time, definitions)
- Future extensibility to RAG or LangChain-style LLM agents

---

## 📦 Tech Stack

| Area              | Technology                               |
|-------------------|-------------------------------------------|
| Backend           | ASP.NET Core 9                            |
| Architecture      | Clean Architecture                        |
| Frontend View     | Razor Pages (MVC Pattern)                 |
| Deployment        | Docker               |
| Real-Time Comm    | WebSocket (SignalR Planned)               |
| Authentication    | JWT (Planned)                             |
| Encryption        | RSA (Planned)                             |
| AI/ML Agent       | ML.NET / Python APIs / LangChain (Planned)|
| Data Storage      | SQL Server / PostgreSQL (Planned)         |
| Testing           | xUnit / NUnit (Planned)                   |

---

## 📁 Project Structure

ChatApp/
├── Chat.API/ # Presentation Layer (Razor Pages)
├── Chat.Application/ # Application Layer (Use Cases, Interfaces)
├── Chat.Domain/ # Domain Layer (Entities, Models)
├── Chat.Infrastructure/ # Infrastructure (WebSockets, DB, External APIs)
│ └── AI/ # AI Agent logic (Planned)
├── Chat.Tests/ # Unit Tests (Planned)
└── Dockerfile # Docker Support


---

## 🔧 Planned Improvements

| Priority | Feature                              | Description                                         |
|----------|--------------------------------------|-----------------------------------------------------|
| 🐳 P1     | Dockerization                        | Containerize the app for easy deployment (Done)           |
| 🔐 P2     | RSA Encryption                       | End-to-end encrypted messaging                     |
| 🔐 P2     | JWT Authentication                   | Secure client identity and session                 |
| 🤖 P2     | AI/ML Agent                          | Add `@Bot` that replies with smart responses       |
| 🧠 P3     | Dynamic Client Tracking              | Show online/offline clients dynamically            |
| 🗃️ P4     | Persist Messages to DB               | Store chat history in SQL DB                       |
| 🧪 P5     | Unit Tests                           | Test business logic, WebSocket handler, etc.       |
| 🔄 P6     | SignalR Migration                    | Replace or extend WebSocket with SignalR framework |

---

## ▶️ Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/)
- Visual Studio 2022 / VS Code
- (Optional) Docker
- (Optional) Python or ML.NET environment for AI agent

### Option 1: Run with Docker (Recommended)

```bash
docker build -t simple-chat-app .
docker run -p 8080:8080 -p 8081:8081 simple-chat-app
````
Then visit: https://localhost:8080/ or whatever port you mapped.

### Option 2: Run Locally with .NET

```bash
dotnet run --project Chat.API
````
Then visit: https://localhost:7016/


💡 License
This project is licensed under the MIT License.

## 🛠️ Contributing

Welcome contributions!

- Fork the repo  
- Create your feature branch  
- Submit a PR  

You can help with:

- AI agent development  
- Frontend UI  
- WebSocket/SignalR scalability  
- Security improvements  
- Writing tests  

👨‍💻 Author
Faojul Ahsan
Senior .NET Backend Developer
🔗 faojulahsan.com

📣 Acknowledgments
This project is part of a long-term vision to build modular, scalable, and ethical software — including secure real-time apps and AI-powered assistants.
