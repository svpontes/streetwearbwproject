👕 Street T-shirt: E-Commerce of Exclusive T-Shirts (BluntWear)
📖 About the Project
Street T-shirt (Brand: BluntWear) is a high-performance web application developed as part of a group project for the course CSE325 .NET Software Development. The platform specializes in the sale of streetwear t-shirts featuring exclusive high-definition (PNG) designs.

This project demonstrates proficiency in the .NET ecosystem, focusing on modern UI/UX practices, state management in Blazor, and robust software architecture.

👥 Development Team
Sergio Pontes - Lead Developer

🛠️ Technology Stack
Framework: .NET 10 Blazor (Interactive Server Mode)

Language: C#

Frontend: HTML5, CSS3 (Bootstrap 5 & Custom Responsive Design)

Icons: Bootstrap Icons

Version Control: Git & GitHub

Project Management: Trello

🏗️ Software Design & Architecture
1. Design Patterns & Logic
State Management (Observer Pattern): Both CartService and AuthService utilize the Observer pattern. Components like NavMenu and Profile subscribe to OnChange events to trigger real-time UI updates (e.g., updating the bag counter or user greeting) without page refreshes.

Dependency Injection (Scoped & Singleton): * CartService: Manages persistent cart state.

AuthService: Handles user session and authentication state across the application.

Component-Based Architecture: High reusability with components like Breadcrumbs, Footer, NavMenu, and ProductCard.

2. Workflow & Logic (UML)
Snippet de código
graph TD
    A[User] -->|Login/Register| B(AuthService)
    B -->|Update State| C[NavMenu: Show User Name]
    A -->|Add to Cart| D(CartService)
    D -->|Trigger Event| E[NavMenu: Update Bag Counter]
    A -->|Navigate| F[MainLayout: Dynamic Breadcrumbs]
    F --> G[Page Content]
✨ Main Features Added
🔐 Authentication & User System
Member Access: Dedicated Login and Registration pages with a "Street/Minimalist" aesthetic.

User Profile: Personal dashboard for logged-in users to view account details and Order History.

Session Header: Dynamic Navigation Menu that toggles between "Login" icon and "User Dropdown" once authenticated.

🗺️ Smart Navigation (Breadcrumbs)
Automatic Path Tracking: A dynamic Breadcrumb system implemented in the MainLayout that automatically maps the user's location (e.g., HOME / CATALOG / PRODUCT).

ID Filtering: Logic to prevent raw database IDs from appearing in the navigation trail, keeping the UI clean.

🛍️ Shopping Experience
Advanced Product Details: Interactive image gallery, size selection (required validation), and dynamic subtotal calculation.

Sticky Footer: A professional 4-column footer with Newsletter integration and social links, designed to stay at the bottom of the viewport.

📱 Responsive UI/UX
Mobile-First Design: Fully responsive Hamburger menu and adapted grid systems for seamless mobile shopping.

Hot Reload Optimized: Structured for fast development cycles using .NET Watch.

🚀 How to Run
Clone: git clone https://github.com/svpontes/streettshirtproject.git

Navigate: cd StreetTshirtApp

Restore & Run: dotnet watch

Access: http://localhost:5067
