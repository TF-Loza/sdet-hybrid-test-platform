# C# SDET Portfolio – UI & API Automation

A hands-on QA Automation portfolio project demonstrating UI and API testing using modern tools and clean framework design.

This project is built using **C#**, **.NET**, **xUnit**, **Playwright**, and **RestSharp**, and demonstrates both UI automation and API testing with a maintainable structure.

---

## 🔧 Tech Stack

- C#
- .NET 10
- xUnit
- Playwright (UI Automation)
- RestSharp (API Testing)
- JSONPlaceholder (test API)
- GitHub Actions (planned)

---

## 📁 Project Structure


sdet-hybrid-test-platform
├── UiTests
│ ├── Framework (BaseTest, BrowserFactory, Settings)
│ ├── Pages (Page Object Model)
│ ├── Tests (UI tests)
│
├── ApiTests
│ ├── Clients (API client)
│ ├── Constants (Endpoints)
│ ├── Models (Request/Response models)
│ ├── Config (Configuration helper)
│ ├── Tests (API tests)


---

## 🧪 UI Automation

- Playwright-based browser automation
- Page Object Model (LoginPage, HomePage)
- Shared setup using `BaseTest` and `IAsyncLifetime`
- Config-driven execution (`appsettings.json`)
- Screenshot capture on test failure

---

## 🔌 API Automation

### Covered operations (CRUD)

- GET all posts
- GET single post
- Filter posts by userId
- POST create post
- PUT update post
- DELETE post

### Negative testing

- Non-existent post handling
- Empty result validation

### Framework features

- Reusable API client
- Endpoint constants
- Request/response models
- JSON deserialization
- Config-driven base URL

---

## 🏷 Test Categorisation

Tests are tagged using xUnit Traits:

- `Type=UI` → UI tests
- `Type=API` → API tests
- `Suite=Smoke` → critical tests
- `Suite=Regression` → extended/edge-case tests

---

## ▶️ Running the Tests

### Restore dependencies


dotnet restore


### Build


dotnet build


### Run all tests


dotnet test


### Run only API tests


dotnet test --filter "Type=API"


### Run only UI tests


dotnet test --filter "Type=UI"


### Run smoke tests only


dotnet test --filter "Suite=Smoke"


---

## 💡 Why I Built This

I built this project to transition into a **QA Automation / SDET role**, focusing on:

- UI automation using Playwright
- API testing using RestSharp
- maintainable test frameworks
- clean code structure
- real-world testing practices

---

## 🚀 Future Improvements

- CI/CD pipeline with GitHub Actions
- HTML test reporting (Allure / ExtentReports)
- Environment-based config (Dev / QA / CI)
- Docker support
- More negative and edge-case tests