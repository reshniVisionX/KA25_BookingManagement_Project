function loadComponent(selector, file) {
  fetch(file)
    .then(res => res.text())
    .then(data => {
      document.querySelector(selector).innerHTML = data;
    });
}

window.addEventListener('DOMContentLoaded', () => {
  loadComponent("#navbar", "Navbar.html");
  loadComponent("#footer", "Footer.html");
});


const routes = {
  "#dashboard": "Dashboard.html",
  "#hotel": "Partials/HotelManagement.html",
  "#restaurant": "Partials/RestaurantManagement.html",
  "#users": "Partials/Users.html",
  "#managers": "Partials/ManagerReq.html",
  "#settings": "Partials/Settings.html"
};

function loadPage(page) {
  fetch(page)
    .then(res => {
      if (!res.ok) throw new Error("Page not found");
      return res.text();
    })
    .then(html => {
      document.getElementById("main-content").innerHTML = html;
    })
    .catch(err => {
      document.getElementById("main-content").innerHTML = "<p>Page not found.</p>";
    });
}

function router() {
  const hash = window.location.hash || "#dashboard";
  const page = routes[hash] || "dashboard.html";
  loadPage(page);

  document.querySelectorAll(".sidebar-nav a").forEach(link => {
    link.classList.toggle("active", link.getAttribute("href") === hash);
  });
}

window.addEventListener("hashchange", router);
window.addEventListener("DOMContentLoaded", router);
