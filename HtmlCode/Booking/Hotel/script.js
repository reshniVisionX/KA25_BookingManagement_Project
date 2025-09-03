const HotelBookingApp = {
  hotels: [
    {
      id: 1,
      name: "Grand Palace Hotel",
      location: "Mumbai, Maharashtra",
      price: 150,
      rating: 4.5,
      image: "https://via.placeholder.com/400x250?text=Grand+Palace",
      images: [
        "https://via.placeholder.com/800x400?text=Grand+Palace+1",
        "https://via.placeholder.com/800x400?text=Grand+Palace+2",
        "https://via.placeholder.com/800x400?text=Grand+Palace+3",
      ],
      description:
        "Experience luxury and comfort at Grand Palace Hotel, located in the heart of Mumbai. Our elegant rooms and world-class amenities ensure an unforgettable stay.",
      amenities: [
        "WiFi",
        "Pool",
        "Gym",
        "Restaurant",
        "Spa",
        "Room Service",
        "Parking",
        "AC",
      ],
      rooms: [
        {
          type: "Standard Room",
          price: 150,
          description: "Comfortable room with city view",
        },
        {
          type: "Deluxe Room",
          price: 200,
          description: "Spacious room with premium amenities",
        },
        {
          type: "Suite",
          price: 350,
          description: "Luxurious suite with separate living area",
        },
      ],
    },
    {
      id: 2,
      name: "Ocean View Resort",
      location: "Goa, India",
      price: 250,
      rating: 4.8,
      image: "https://via.placeholder.com/400x250?text=Ocean+View",
      images: [
        "https://via.placeholder.com/800x400?text=Ocean+View+1",
        "https://via.placeholder.com/800x400?text=Ocean+View+2",
        "https://via.placeholder.com/800x400?text=Ocean+View+3",
      ],
      description:
        "Relax and unwind at Ocean View Resort, where pristine beaches meet luxury accommodation. Perfect for a romantic getaway or family vacation.",
      amenities: [
        "Beach Access",
        "WiFi",
        "Pool",
        "Restaurant",
        "Bar",
        "Water Sports",
        "Spa",
        "AC",
      ],
      rooms: [
        {
          type: "Beach View Room",
          price: 250,
          description: "Room with stunning ocean views",
        },
        {
          type: "Beachfront Villa",
          price: 400,
          description: "Private villa steps from the beach",
        },
        {
          type: "Presidential Suite",
          price: 600,
          description: "Ultimate luxury with private beach access",
        },
      ],
    },
    {
      id: 3,
      name: "City Center Inn",
      location: "Delhi, India",
      price: 80,
      rating: 4.0,
      image: "https://via.placeholder.com/400x250?text=City+Center",
      images: [
        "https://via.placeholder.com/800x400?text=City+Center+1",
        "https://via.placeholder.com/800x400?text=City+Center+2",
        "https://via.placeholder.com/800x400?text=City+Center+3",
      ],
      description:
        "Budget-friendly accommodation in the heart of Delhi. Perfect for business travelers and tourists looking for convenience and value.",
      amenities: [
        "WiFi",
        "Restaurant",
        "24/7 Front Desk",
        "Laundry",
        "AC",
        "Room Service",
      ],
      rooms: [
        {
          type: "Economy Room",
          price: 80,
          description: "Basic room with essential amenities",
        },
        {
          type: "Business Room",
          price: 120,
          description: "Room with work desk and better amenities",
        },
        {
          type: "Family Room",
          price: 180,
          description: "Spacious room suitable for families",
        },
      ],
    },
    {
      id: 4,
      name: "Mountain Retreat",
      location: "Bangalore, Karnataka",
      price: 180,
      rating: 4.3,
      image: "https://via.placeholder.com/400x250?text=Mountain+Retreat",
      images: [
        "https://via.placeholder.com/800x400?text=Mountain+Retreat+1",
        "https://via.placeholder.com/800x400?text=Mountain+Retreat+2",
        "https://via.placeholder.com/800x400?text=Mountain+Retreat+3",
      ],
      description:
        "Escape to nature at Mountain Retreat, offering serene views and fresh air. Ideal for those seeking peace and tranquility.",
      amenities: [
        "WiFi",
        "Restaurant",
        "Garden",
        "Hiking Trails",
        "Bonfire",
        "Room Service",
        "Parking",
      ],
      rooms: [
        {
          type: "Garden View Room",
          price: 180,
          description: "Room overlooking beautiful gardens",
        },
        {
          type: "Mountain View Room",
          price: 230,
          description: "Room with panoramic mountain views",
        },
        {
          type: "Cottage",
          price: 320,
          description: "Private cottage in nature setting",
        },
      ],
    },
  ],
  reviews: {
    1: [
      {
        id: 1,
        reviewerName: "Alice Smith",
        reviewText:
          "Amazing stay! The staff was very friendly and the rooms were luxurious.",
        rating: 5,
        date: "2025-08-15",
      },
      {
        id: 2,
        reviewerName: "Bob Johnson",
        reviewText: "Great location, but the WiFi was a bit slow.",
        rating: 4,
        date: "2025-08-20",
      },
    ],
    2: [
      {
        id: 3,
        reviewerName: "Carol Williams",
        reviewText: "Perfect beach getaway! Loved the ocean views.",
        rating: 5,
        date: "2025-07-10",
      },
    ],
    3: [
      {
        id: 4,
        reviewerName: "David Brown",
        reviewText: "Good value for money, centrally located.",
        rating: 4,
        date: "2025-08-01",
      },
    ],
    4: [
      {
        id: 5,
        reviewerName: "Emma Davis",
        reviewText: "Peaceful retreat with beautiful scenery.",
        rating: 4.5,
        date: "2025-08-25",
      },
    ],
  },
  watchlist: [],
  bookings: [
    {
      bookingId: "BK1725283200000",
      hotel: {
        id: 1,
        name: "Grand Palace Hotel",
        location: "Mumbai, Maharashtra",
        image: "https://via.placeholder.com/400x250?text=Grand+Palace",
      },
      checkinDate: "2025-09-02",
      checkoutDate: "2025-09-03",
      guestCount: "2",
      roomType: "Deluxe Room",
      guestName: "John Doe",
      guestEmail: "john@example.com",
      guestPhone: "1234567890",
      specialRequests: "",
      nights: 2,
      subtotal: 400,
      taxes: 72,
      total: 472,
      status: "Confirmed",
      bookingDate: "2025-08-30",
    },
  ],
  currentHotel: null,
  currentBooking: null,
  editingHotelId: null,
  init() {
    this.loadFromStorage();
    this.setupEventListeners();
    this.showPage("hotel-list");
    this.renderHotels();
  },
  loadFromStorage() {
    const savedWatchlist = localStorage.getItem("hotelWatchlist");
    if (savedWatchlist) this.watchlist = JSON.parse(savedWatchlist);
    const savedBookings = localStorage.getItem("hotelBookings");
    if (savedBookings) this.bookings = JSON.parse(savedBookings);
    const savedReviews = localStorage.getItem("hotelReviews");
    if (savedReviews) this.reviews = JSON.parse(savedReviews);
    const savedHotels = localStorage.getItem("customHotels");
    if (savedHotels) {
      const customHotels = JSON.parse(savedHotels);
      this.hotels = [...this.hotels, ...customHotels];
    }
  },
  saveToStorage() {
    localStorage.setItem("hotelWatchlist", JSON.stringify(this.watchlist));
    localStorage.setItem("hotelBookings", JSON.stringify(this.bookings));
    localStorage.setItem("hotelReviews", JSON.stringify(this.reviews));
    const customHotels = this.hotels.filter((hotel) => hotel.id > 4);
    localStorage.setItem("customHotels", JSON.stringify(customHotels));
  },
  setupEventListeners() {
    document.querySelectorAll(".nav-link").forEach((link) => {
      link.addEventListener("click", (e) => {
        e.preventDefault();
        const page = link.getAttribute("data-page");
        this.showPage(page);
      });
    });
    document
      .getElementById("searchInput")
      .addEventListener("input", () => this.applyFilters());
    document
      .getElementById("sortFilter")
      .addEventListener("change", () => this.applyFilters());
    document
      .getElementById("priceFilter")
      .addEventListener("change", () => this.applyFilters());
    document
      .getElementById("locationFilter")
      .addEventListener("change", () => this.applyFilters());
    document
      .getElementById("ratingFilter")
      .addEventListener("change", () => this.applyFilters());
    document
      .getElementById("bookNowBtn")
      .addEventListener("click", () => this.startBooking());
    document
      .getElementById("addToWatchlistBtn")
      .addEventListener("click", () => this.toggleWatchlist());
    document
      .querySelector(".carousel-prev")
      .addEventListener("click", () => this.prevImage());
    document
      .querySelector(".carousel-next")
      .addEventListener("click", () => this.nextImage());
    document
      .getElementById("reviewForm")
      .addEventListener("submit", (e) => this.submitReview(e));
    document.querySelectorAll(".star-btn").forEach((btn) => {
      btn.addEventListener("click", (e) => this.setRating(e));
    });
    document
      .getElementById("bookingForm")
      .addEventListener("submit", (e) => this.processBooking(e));
    document.getElementById("checkinDate").addEventListener("change", () => {
      this.updateCheckoutDate();
      this.calculatePrice();
    });
    document
      .getElementById("checkoutDate")
      .addEventListener("change", () => this.calculatePrice());
    document
      .getElementById("roomType")
      .addEventListener("change", () => this.calculatePrice());
    document.querySelectorAll(".payment-method").forEach((method) => {
      method.addEventListener("click", (e) => this.selectPaymentMethod(e));
    });
    document
      .getElementById("paymentForm")
      .addEventListener("submit", (e) => this.processPayment(e));
    document.querySelectorAll(".admin-nav-link").forEach((link) => {
      link.addEventListener("click", (e) => this.showAdminSection(e));
    });
    document
      .getElementById("addHotelBtn")
      .addEventListener("click", () => this.showHotelForm());
    document
      .getElementById("adminHotelForm")
      .addEventListener("submit", (e) => this.saveHotel(e));
    document
      .getElementById("cancelHotelBtn")
      .addEventListener("click", () => this.hideHotelForm());
    this.setMinDate();
  },
  setMinDate() {
    const today = new Date().toISOString().split("T")[0];
    document.getElementById("checkinDate").min = today;
    document.getElementById("checkoutDate").min = today;
  },
  updateCheckoutDate() {
    const checkinDate = document.getElementById("checkinDate").value;
    if (checkinDate) {
      const checkin = new Date(checkinDate);
      const nextDay = new Date(checkin);
      nextDay.setDate(checkin.getDate() + 1);
      document.getElementById("checkoutDate").min = nextDay
        .toISOString()
        .split("T")[0];
      if (
        document.getElementById("checkoutDate").value &&
        new Date(document.getElementById("checkoutDate").value) < checkin
      ) {
        document.getElementById("checkoutDate").value = "";
      }
    }
  },
  showPage(pageName) {
    document.querySelectorAll(".page").forEach((page) => {
      page.style.display = "none";
    });
    document.getElementById(pageName + "-page").style.display = "block";
    document.querySelectorAll(".nav-link").forEach((link) => {
      link.classList.remove("active");
    });
    document.querySelector(`[data-page="${pageName}"]`).classList.add("active");
    switch (pageName) {
      case "hotel-list":
        this.renderHotels();
        break;
      case "watchlist":
        this.renderWatchlist();
        break;
      case "booking-history":
        this.renderBookingHistory();
        break;
      case "admin":
        this.renderAdminData();
        break;
    }
  },
  renderHotels(hotelsToRender = null) {
    const container = document.getElementById("hotelsContainer");
    const hotels = hotelsToRender || this.hotels;
    if (hotels.length === 0) {
      container.innerHTML = `
                <div class="empty-state">
                    <div class="empty-state-icon">🏨</div>
                    <h3>No hotels found</h3>
                    <p>Try adjusting your search criteria</p>
                </div>
            `;
      return;
    }
    container.innerHTML = hotels
      .map(
        (hotel) => `
            <div class="hotel-card fade-in">
                <img src="${hotel.image}" alt="${hotel.name}" class="hotel-image">
                <div class="hotel-info">
                    <h3 class="hotel-name">${hotel.name}</h3>
                    <p class="hotel-location">📍 ${hotel.location}</p>
                    <div class="hotel-rating">
                        <span class="stars">${"★".repeat(Math.floor(hotel.rating))}${"☆".repeat(5 - Math.floor(hotel.rating))}</span>
                        <span>${hotel.rating}</span>
                    </div>
                    <div class="hotel-price">₹${hotel.price}/night</div>
                    <div class="hotel-buttons">
                        <button class="btn btn-primary" onclick="HotelBookingApp.viewHotelDetails(${hotel.id})">View Details</button>
                        <button class="btn btn-secondary" onclick="HotelBookingApp.quickBook(${hotel.id})">Book Now</button>
                        <button class="btn btn-outline" onclick="HotelBookingApp.toggleWatchlistFromList(${hotel.id})">
                            ${this.isInWatchlist(hotel.id) ? "💖" : "🤍"}
                        </button>
                    </div>
                </div>
            </div>
        `
      )
      .join("");
  },
  applyFilters() {
    const search = document.getElementById("searchInput").value.toLowerCase();
    const sort = document.getElementById("sortFilter").value;
    const priceRange = document.getElementById("priceFilter").value;
    const location = document.getElementById("locationFilter").value;
    const rating = document.getElementById("ratingFilter").value;
    let filteredHotels = [...this.hotels];
    if (search) {
      filteredHotels = filteredHotels.filter(
        (hotel) =>
          hotel.name.toLowerCase().includes(search) ||
          hotel.location.toLowerCase().includes(search)
      );
    }
    if (priceRange !== "all") {
      const [min, max] = priceRange.split("-").map((p) => p.replace("+", ""));
      filteredHotels = filteredHotels.filter((hotel) => {
        if (max) {
          return hotel.price >= parseInt(min) && hotel.price <= parseInt(max);
        } else {
          return hotel.price >= parseInt(min);
        }
      });
    }
    if (location !== "all") {
      filteredHotels = filteredHotels.filter((hotel) =>
        hotel.location.toLowerCase().includes(location)
      );
    }
    if (rating !== "all") {
      filteredHotels = filteredHotels.filter(
        (hotel) => hotel.rating >= parseInt(rating)
      );
    }
    switch (sort) {
      case "price-low":
        filteredHotels.sort((a, b) => a.price - b.price);
        break;
      case "price-high":
        filteredHotels.sort((a, b) => b.price - a.price);
        break;
      case "rating":
        filteredHotels.sort((a, b) => b.rating - a.rating);
        break;
      case "name":
        filteredHotels.sort((a, b) => a.name.localeCompare(b.name));
        break;
    }
    this.renderHotels(filteredHotels);
  },
  viewHotelDetails(hotelId) {
    console.log(`Viewing details for hotel ID: ${hotelId}`);
    this.currentHotel = this.hotels.find((h) => h.id === hotelId);
    if (
      !this.currentHotel ||
      !this.currentHotel.rooms ||
      this.currentHotel.rooms.length === 0
    ) {
      console.error(`Hotel with ID ${hotelId} not found or has no rooms`, {
        hotel: this.currentHotel,
      });
      alert(
        "Hotel not found or has no available rooms. Please try another hotel."
      );
      this.showPage("hotel-list");
      return;
    }
    console.log("Current Hotel:", this.currentHotel);
    this.showPage("hotel-details");
    this.renderHotelDetails();
  },
  renderHotelDetails() {
    if (!this.currentHotel) {
      console.error("No current hotel set for rendering details");
      document.getElementById("hotelDescription").textContent =
        "Error: Hotel data not available";
      return;
    }
    const hotel = this.currentHotel;
    console.log("Rendering details for:", hotel.name);

    document.getElementById("hotelName").textContent =
      hotel.name || "Unknown Hotel";
    document.getElementById("hotelLocation").textContent =
      hotel.location || "Unknown Location";
    document.getElementById("hotelStars").textContent =
      "★".repeat(Math.floor(hotel.rating || 0)) +
      "☆".repeat(5 - Math.floor(hotel.rating || 0));
    document.getElementById("hotelRating").textContent = hotel.rating || "N/A";

    document.getElementById("hotelDescription").textContent =
      hotel.description || "No description available for this hotel.";

    const carouselContainer = document.getElementById("carouselImages");
    if (carouselContainer) {
      carouselContainer.innerHTML =
        hotel.images && hotel.images.length > 0
          ? hotel.images
              .map(
                (img, index) => `
                    <img src="${img}" alt="${hotel.name}" class="carousel-slide ${
                  index === 0 ? "active" : ""
                }" data-index="${index}">
                  `
              )
              .join("")
          : "<p>No images available</p>";
    } else {
      console.error("Carousel container not found");
    }

    const amenitiesList = document.getElementById("amenitiesList");
    if (amenitiesList) {
      amenitiesList.innerHTML =
        hotel.amenities && hotel.amenities.length > 0
          ? hotel.amenities
              .map(
                (amenity) => `
                    <div class="amenity-item">${amenity}</div>
                  `
              )
              .join("")
          : "<p>No amenities listed</p>";
    } else {
      console.error("Amenities list container not found");
    }

    const roomsGrid = document.getElementById("roomsGrid");
    if (roomsGrid) {
      roomsGrid.innerHTML =
        hotel.rooms && hotel.rooms.length > 0
          ? hotel.rooms
              .map(
                (room) => `
                    <div class="room-card" data-type="${room.type}" data-price="${room.price}">
                        <h4>${room.type}</h4>
                        <p>${room.description}</p>
                        <div class="hotel-price">₹${room.price}/night</div>
                    </div>
                  `
              )
              .join("")
          : "<p>No rooms available</p>";
    } else {
      console.error("Rooms grid container not found");
    }

    const watchlistBtn = document.getElementById("addToWatchlistBtn");
    if (watchlistBtn) {
      watchlistBtn.textContent = this.isInWatchlist(hotel.id)
        ? "Remove from Watchlist"
        : "Add to Watchlist";
    }

    this.renderReviews();
  },
  prevImage() {
    const slides = document.querySelectorAll(".carousel-slide");
    const current = document.querySelector(".carousel-slide.active");
    const currentIndex = parseInt(current.getAttribute("data-index"));
    const prevIndex = currentIndex === 0 ? slides.length - 1 : currentIndex - 1;
    current.classList.remove("active");
    slides[prevIndex].classList.add("active");
  },
  nextImage() {
    const slides = document.querySelectorAll(".carousel-slide");
    const current = document.querySelector(".carousel-slide.active");
    const currentIndex = parseInt(current.getAttribute("data-index"));
    const nextIndex = currentIndex === slides.length - 1 ? 0 : currentIndex + 1;
    current.classList.remove("active");
    slides[nextIndex].classList.add("active");
  },
  toggleWatchlist() {
    const hotelId = this.currentHotel.id;
    const index = this.watchlist.findIndex((id) => id === hotelId);
    if (index > -1) {
      this.watchlist.splice(index, 1);
    } else {
      this.watchlist.push(hotelId);
    }
    this.saveToStorage();
    this.renderHotelDetails();
  },
  toggleWatchlistFromList(hotelId) {
    const index = this.watchlist.findIndex((id) => id === hotelId);
    if (index > -1) {
      this.watchlist.splice(index, 1);
    } else {
      this.watchlist.push(hotelId);
    }
    this.saveToStorage();
    this.renderHotels();
  },
  isInWatchlist(hotelId) {
    return this.watchlist.includes(hotelId);
  },
  setRating(e) {
    const rating = parseInt(e.target.getAttribute("data-rating"));
    document.querySelectorAll(".star-btn").forEach((star, index) => {
      star.classList.toggle("active", index < rating);
    });
  },
  submitReview(e) {
    e.preventDefault();
    const hotelId = this.currentHotel.id;
    const reviewerName = document.getElementById("reviewerName").value;
    const reviewText = document.getElementById("reviewText").value;
    const rating = document.querySelectorAll(".star-btn.active").length;
    if (rating === 0) {
      alert("Please select a rating");
      return;
    }
    if (!this.reviews[hotelId]) {
      this.reviews[hotelId] = [];
    }
    const review = {
      id: Date.now(),
      reviewerName,
      reviewText,
      rating,
      date: new Date().toLocaleDateString(),
    };
    this.reviews[hotelId].push(review);
    this.saveToStorage();
    document.getElementById("reviewForm").reset();
    document
      .querySelectorAll(".star-btn")
      .forEach((star) => star.classList.remove("active"));
    this.renderReviews();
    const successMsg = document.createElement("div");
    successMsg.className = "success";
    successMsg.textContent = "Review submitted successfully!";
    document
      .getElementById("reviewForm")
      .parentNode.insertBefore(successMsg, document.getElementById("reviewForm"));
    setTimeout(() => successMsg.remove(), 3000);
  },
  renderReviews() {
    const hotelId = this.currentHotel.id;
    const reviews = this.reviews[hotelId] || [];
    const reviewsList = document.getElementById("reviewsList");
    if (reviews.length === 0) {
      reviewsList.innerHTML = `
                <div class="empty-state">
                    <p>No reviews yet. Be the first to review!</p>
                </div>
            `;
      return;
    }
    reviewsList.innerHTML = reviews
      .map(
        (review) => `
            <div class="review-card">
                <div class="review-header">
                    <span class="reviewer-name">${review.reviewerName}</span>
                    <div>
                        <span class="stars">${"★".repeat(review.rating)}${"☆".repeat(5 - review.rating)}</span>
                        <span class="review-date">${review.date}</span>
                    </div>
                </div>
                <p>${review.reviewText}</p>
            </div>
        `
      )
      .join("");
  },
  startBooking() {
    if (!this.currentHotel) {
      console.error("No current hotel set for booking");
      alert("Please select a hotel to book.");
      this.showPage("hotel-list");
      return;
    }
    console.log("Starting booking for:", this.currentHotel.name);
    this.showPage("booking");
    this.setupBookingForm();
  },
  quickBook(hotelId) {
    console.log(`Quick booking for hotel ID: ${hotelId}`);
    this.currentHotel = this.hotels.find((h) => h.id === hotelId);
    if (
      !this.currentHotel ||
      !this.currentHotel.rooms ||
      this.currentHotel.rooms.length === 0
    ) {
      console.error(`Hotel with ID ${hotelId} not found or has no rooms`, {
        hotel: this.currentHotel,
      });
      alert(
        "Hotel not found or has no available rooms. Please try another hotel."
      );
      this.showPage("hotel-list");
      return;
    }
    this.startBooking();
  },
  setupBookingForm() {
    console.log(
      "Setting up booking form, currentHotel:",
      this.currentHotel ? this.currentHotel.name : "undefined"
    );

    const bookingPage = document.getElementById("booking-page");
    const bookingForm = document.getElementById("bookingForm");
    const roomTypeSelect = document.getElementById("roomType");

    // Clear any existing error messages
    const existingErrors = document.querySelectorAll("#bookingForm .error");
    existingErrors.forEach((error) => error.remove());

    // Ensure booking page and form are visible
    if (bookingPage) {
      bookingPage.style.display = "block";
    } else {
      console.error("Booking page not found");
    }
    if (bookingForm) {
      bookingForm.style.display = "block";
    } else {
      console.error("Booking form not found");
    }

    // Validate currentHotel and rooms
    if (
      !this.currentHotel ||
      !this.currentHotel.rooms ||
      this.currentHotel.rooms.length === 0
    ) {
      console.error("No valid hotel or rooms available", {
        currentHotel: this.currentHotel,
        rooms: this.currentHotel?.rooms,
      });
      const errorMsg = document.createElement("div");
      errorMsg.className = "error";
      errorMsg.textContent =
        "No rooms available for this hotel. Please select another hotel.";
      bookingForm.prepend(errorMsg);
      setTimeout(() => errorMsg.remove(), 5000);
      this.showPage("hotel-list");
      return;
    }

    // Populate room type select options
    if (roomTypeSelect) {
      roomTypeSelect.innerHTML = '<option value="">Select Room Type</option>';
      this.currentHotel.rooms.forEach((room) => {
        const option = document.createElement("option");
        option.value = room.type;
        option.textContent = `${room.type} - ₹${room.price}/night`;
        option.setAttribute("data-price", room.price);
        roomTypeSelect.appendChild(option);
      });

      // Set default room type (first room) if available
      if (this.currentHotel.rooms.length > 0) {
        roomTypeSelect.value = this.currentHotel.rooms[0].type;
      } else {
        roomTypeSelect.value = ""; // Ensure no invalid default if no rooms
      }
    } else {
      console.error("Room type select element not found");
      const errorMsg = document.createElement("div");
      errorMsg.className = "error";
      errorMsg.textContent =
        "Error: Booking form is not properly loaded. Please try again.";
      bookingForm.prepend(errorMsg);
      setTimeout(() => errorMsg.remove(), 5000);
      this.showPage("hotel-list");
      return;
    }

    // Reset and set default form fields
    bookingForm.reset();
    const today = new Date().toISOString().split("T")[0];
    document.getElementById("checkinDate").value = today;
    document.getElementById("checkinDate").min = today;
    document.getElementById("checkoutDate").min = today;
    this.updateCheckoutDate();
    this.calculatePrice(); // Recalculate price with default values
  },
  calculatePrice() {
    const checkinDate = document.getElementById("checkinDate").value;
    const checkoutDate = document.getElementById("checkoutDate").value;
    const roomTypeSelect = document.getElementById("roomType");

    // Log values for debugging
    console.log("Check-in:", checkinDate);
    console.log("Check-out:", checkoutDate);
    console.log("Room Type:", roomTypeSelect.value);

    if (!checkinDate || !checkoutDate || !roomTypeSelect.value) {
      document.getElementById("priceBreakdown").innerHTML = `
        <div class="error">Please select valid dates and room type</div>
      `;
      return;
    }

    const checkin = new Date(checkinDate);
    const checkout = new Date(checkoutDate);
    if (
      isNaN(checkin.getTime()) ||
      isNaN(checkout.getTime()) ||
      checkout <= checkin
    ) {
      document.getElementById("priceBreakdown").innerHTML = `
        <div class="error">Please select valid dates (check-out must be after check-in)</div>
      `;
      return;
    }

    const nights = Math.ceil((checkout - checkin) / (1000 * 60 * 60 * 24));
    if (nights <= 0) {
      document.getElementById("priceBreakdown").innerHTML = `
        <div class="error">Check-out date must be after check-in date</div>
      `;
      return;
    }

    const selectedOption = roomTypeSelect.selectedOptions[0];
    const roomPrice = parseInt(selectedOption.getAttribute("data-price"));
    const roomType = roomTypeSelect.value;
    const subtotal = roomPrice * nights;
    const taxes = Math.round(subtotal * 0.18);
    const total = subtotal + taxes;

    document.getElementById("priceBreakdown").innerHTML = `
      <h4>Price Breakdown</h4>
      <div class="price-row">
        <span>${roomType} × ${nights} nights</span>
        <span>₹${subtotal}</span>
      </div>
      <div class="price-row">
        <span>Taxes & Fees</span>
        <span>₹${taxes}</span>
      </div>
      <div class="price-row total-price">
        <span>Total Amount</span>
        <span>₹${total}</span>
      </div>
    `;
  },
  processBooking(e) {
    e.preventDefault();
    const formData = {
      hotel: this.currentHotel,
      checkinDate: document.getElementById("checkinDate").value,
      checkoutDate: document.getElementById("checkoutDate").value,
      guestCount: document.getElementById("guestCount").value,
      roomType: document.getElementById("roomType").value,
      guestName: document.getElementById("guestName").value,
      guestEmail: document.getElementById("guestEmail").value,
      guestPhone: document.getElementById("guestPhone").value,
      specialRequests: document.getElementById("specialRequests").value,
    };

    const checkin = new Date(formData.checkinDate);
    const checkout = new Date(formData.checkoutDate);
    if (
      isNaN(checkin.getTime()) ||
      isNaN(checkout.getTime()) ||
      checkout <= checkin
    ) {
      const errorMsg = document.createElement("div");
      errorMsg.className = "error";
      errorMsg.textContent = "Please select valid dates (check-out must be after check-in).";
      document.getElementById("bookingForm").prepend(errorMsg);
      setTimeout(() => errorMsg.remove(), 5000);
      return;
    }

    if (!formData.roomType || !this.currentHotel.rooms.find((r) => r.type === formData.roomType)) {
      const errorMsg = document.createElement("div");
      errorMsg.className = "error";
      errorMsg.textContent = "Please select a valid room type.";
      document.getElementById("bookingForm").prepend(errorMsg);
      setTimeout(() => errorMsg.remove(), 5000);
      return;
    }

    if (!formData.guestName || !formData.guestEmail || !formData.guestPhone) {
      const errorMsg = document.createElement("div");
      errorMsg.className = "error";
      errorMsg.textContent = "Please fill in all guest details (name, email, phone).";
      document.getElementById("bookingForm").prepend(errorMsg);
      setTimeout(() => errorMsg.remove(), 5000);
      return;
    }

    this.currentBooking = formData;
    this.showPage("payment");
    this.setupPaymentForm();
  },
  setupPaymentForm() {
    const booking = this.currentBooking;
    const checkin = new Date(booking.checkinDate);
    const checkout = new Date(booking.checkoutDate);
    const nights = Math.ceil((checkout - checkin) / (1000 * 60 * 60 * 24));
    const roomPrice = this.currentHotel.rooms.find(
      (r) => r.type === booking.roomType
    ).price;
    const subtotal = roomPrice * nights;
    const taxes = Math.round(subtotal * 0.18);
    const total = subtotal + taxes;
    document.getElementById("paymentSummary").innerHTML = `
            <h4>Booking Summary</h4>
            <div class="price-row">
                <span><strong>${booking.hotel.name}</strong></span>
            </div>
            <div class="price-row">
                <span>${booking.checkinDate} to ${booking.checkoutDate}</span>
                <span>${nights} nights</span>
            </div>
            <div class="price-row">
                <span>${booking.roomType}</span>
                <span>₹${subtotal}</span>
            </div>
            <div class="price-row">
                <span>Taxes & Fees</span>
                <span>₹${taxes}</span>
            </div>
            <div class="price-row total-price">
                <span>Total Amount</span>
                <span>₹${total}</span>
            </div>
        `;
  },
  selectPaymentMethod(e) {
    document.querySelectorAll(".payment-method").forEach((method) => {
      method.classList.remove("active");
    });
    e.currentTarget.classList.add("active");
    const method = e.currentTarget.getAttribute("data-method");
    document.querySelectorAll(".payment-form").forEach((form) => {
      form.style.display = "none";
    });
    document.getElementById(method + "Payment").style.display = "block";
  },
  processPayment(e) {
    e.preventDefault();
    console.log("Processing payment...");

    // Clear any existing error messages
    const existingErrors = document.querySelectorAll("#paymentForm .error");
    existingErrors.forEach((error) => error.remove());

    // Validate currentBooking and currentHotel
    if (!this.currentBooking || !this.currentHotel) {
      console.error(
        "Payment error: currentBooking or currentHotel is not set",
        {
          currentBooking: this.currentBooking,
          currentHotel: this.currentHotel,
        }
      );
      const errorMsg = document.createElement("div");
      errorMsg.className = "error";
      errorMsg.textContent =
        "Error: Booking data is missing. Please start over.";
      document.getElementById("paymentForm").prepend(errorMsg);
      setTimeout(() => errorMsg.remove(), 5000);
      return;
    }

    // Validate roomType
    if (
      !this.currentBooking.roomType ||
      !this.currentHotel.rooms.find(
        (r) => r.type === this.currentBooking.roomType
      )
    ) {
      console.error("Payment error: Invalid or missing room type", {
        roomType: this.currentBooking.roomType,
        availableRooms: this.currentHotel.rooms,
      });
      const errorMsg = document.createElement("div");
      errorMsg.className = "error";
      errorMsg.textContent = "Error: Invalid room type. Please start over.";
      document.getElementById("paymentForm").prepend(errorMsg);
      setTimeout(() => errorMsg.remove(), 5000);
      return;
    }

    const activeMethod = document
      .querySelector(".payment-method.active")
      ?.getAttribute("data-method");
    if (!activeMethod) {
      console.error("No payment method selected");
      const errorMsg = document.createElement("div");
      errorMsg.className = "error";
      errorMsg.textContent = "Please select a payment method.";
      document.getElementById("paymentForm").prepend(errorMsg);
      setTimeout(() => errorMsg.remove(), 5000);
      return;
    }

    let isValid = false;
    let errorMessage = "";

    switch (activeMethod) {
      case "card":
        const cardNumber = document
          .getElementById("cardNumber")
          .value.replace(/\s/g, "");
        const cardName = document.getElementById("cardName").value.trim();
        const cardExpiry = document.getElementById("cardExpiry").value;
        const cardCvv = document.getElementById("cardCvv").value;
        if (
          /^\d{12,19}$/.test(cardNumber) &&
          cardName &&
          /^(\d{2}\/\d{2}|\d{2}\/\d{4})$/.test(cardExpiry) &&
          /^\d{3,4}$/.test(cardCvv)
        ) {
          isValid = true;
        } else {
          errorMessage =
            "Invalid card details. Please check card number (12-19 digits), name, expiry (MM/YY or MM/YYYY), and CVV (3-4 digits).";
        }
        break;
      case "upi":
        const upiId = document.getElementById("upiId").value.trim();
        console.log("Validating UPI ID:", upiId);
        const upiRegex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]{2,}$/;
        if (upiRegex.test(upiId)) {
          console.log("UPI ID valid:", upiId);
          isValid = true;
        } else {
          console.log("UPI ID invalid:", upiId);
          errorMessage =
            "Invalid UPI ID. Please enter a valid ID (e.g., yourname@upi, user@ybl).";
        }
        break;
      case "netbanking":
        const bank = document.getElementById("bankSelect").value;
        if (bank) {
          isValid = true;
        } else {
          errorMessage = "Please select a bank.";
        }
        break;
    }

    const paymentForm = document.getElementById("paymentForm");
    const loadingBtn = paymentForm.querySelector('button[type="submit"]');

    if (!isValid) {
      console.error("Payment validation failed:", errorMessage);
      const errorMsg = document.createElement("div");
      errorMsg.className = "error";
      errorMsg.textContent = errorMessage;
      paymentForm.prepend(errorMsg);
      setTimeout(() => errorMsg.remove(), 5000);
      return;
    }

    console.log("Payment details valid, simulating processing...");
    loadingBtn.textContent = "Processing Payment...";
    loadingBtn.disabled = true;

    setTimeout(() => {
      try {
        this.completeBooking();
        console.log("Payment processed successfully");
      } catch (error) {
        console.error("Error in completeBooking:", error.message, error.stack);
        const errorMsg = document.createElement("div");
        errorMsg.className = "error";
        errorMsg.textContent =
          error.message ||
          "Payment processing failed due to an internal error. Please try again.";
        paymentForm.prepend(errorMsg);
        setTimeout(() => errorMsg.remove(), 5000);
      } finally {
        loadingBtn.textContent = "Complete Payment";
        loadingBtn.disabled = false;
      }
    }, 2000);
  },
  completeBooking() {
    console.log("Starting completeBooking with:", {
      currentBooking: this.currentBooking,
      currentHotel: this.currentHotel ? this.currentHotel.name : "undefined",
    });

    if (!this.currentBooking || !this.currentHotel) {
      throw new Error("Cannot complete booking: Booking or hotel data is missing");
    }

    const booking = this.currentBooking;
    if (!booking.roomType || !booking.checkinDate || !booking.checkoutDate) {
      console.error("Incomplete booking data:", booking);
      throw new Error(
        "Incomplete booking data: Please ensure all booking details are provided"
      );
    }

    const checkin = new Date(booking.checkinDate);
    const checkout = new Date(booking.checkoutDate);
    const nights = Math.ceil((checkout - checkin) / (1000 * 60 * 60 * 24));
    console.log("Calculated nights:", nights, {
      checkin: booking.checkinDate,
      checkout: booking.checkoutDate,
    });

    if (isNaN(nights) || nights <= 0) {
      throw new Error("Invalid booking dates: Check-out must be after check-in");
    }

    const room = this.currentHotel.rooms.find((r) => r.type === booking.roomType);
    if (!room) {
      console.error(
        "Room type not found:",
        booking.roomType,
        "Available rooms:",
        this.currentHotel.rooms
      );
      throw new Error(
        `Invalid room type: ${booking.roomType} not available for this hotel`
      );
    }

    const roomPrice = room.price;
    console.log("Room price:", roomPrice, "for room type:", booking.roomType);

    const subtotal = roomPrice * nights;
    const taxes = Math.round(subtotal * 0.18);
    const total = subtotal + taxes;

    const finalBooking = {
      ...booking,
      bookingId: "BK" + Date.now(),
      nights,
      subtotal,
      taxes,
      total,
      status: "Confirmed",
      bookingDate: new Date().toLocaleDateString(),
    };

    console.log("Final booking object:", finalBooking);

    try {
      this.bookings.push(finalBooking);
      this.saveToStorage();
    } catch (error) {
      console.error("Error saving booking to storage:", error);
      throw new Error("Failed to save booking. Please try again.");
    }

    this.currentBooking = null;
    this.showBookingSuccess(finalBooking);
    console.log("Booking completed successfully:", finalBooking);
  },
  showBookingSuccess(booking) {
    this.showPage("payment-success");
    document.getElementById("bookingSummary").innerHTML = `
            <h4>Booking Details</h4>
            <div class="price-row">
                <span><strong>Booking ID:</strong></span>
                <span><strong>${booking.bookingId}</strong></span>
            </div>
            <div class="price-row">
                <span>Hotel:</span>
                <span>${booking.hotel.name}</span>
            </div>
            <div class="price-row">
                <span>Guest Name:</span>
                <span>${booking.guestName}</span>
            </div>
            <div class="price-row">
                <span>Email:</span>
                <span>${booking.guestEmail}</span>
            </div>
            <div class="price-row">
                <span>Check-in:</span>
                <span>${booking.checkinDate}</span>
            </div>
            <div class="price-row">
                <span>Check-out:</span>
                <span>${booking.checkoutDate}</span>
            </div>
            <div class="price-row">
                <span>Room Type:</span>
                <span>${booking.roomType}</span>
            </div>
            <div class="price-row">
                <span>Guests:</span>
                <span>${booking.guestCount}</span>
            </div>
            <div class="price-row total-price">
                <span>Total Paid:</span>
                <span>₹${booking.total}</span>
            </div>
            <p style="margin-top: 15px; text-align: center; color: #666;">
                A confirmation email has been sent to ${booking.guestEmail}
            </p>
        `;
  },
  renderWatchlist() {
    const watchlistedHotels = this.hotels.filter((hotel) =>
      this.watchlist.includes(hotel.id)
    );
    const container = document.getElementById("watchlistContainer");
    if (watchlistedHotels.length === 0) {
      container.innerHTML = `
                <div class="empty-state">
                    <div class="empty-state-icon">💔</div>
                    <h3>Your watchlist is empty</h3>
                    <p>Add hotels to your watchlist to see them here</p>
                    <button class="btn btn-primary" onclick="HotelBookingApp.showPage('hotel-list')">Browse Hotels</button>
                </div>
            `;
      return;
    }
    container.innerHTML = watchlistedHotels
      .map(
        (hotel) => `
            <div class="hotel-card fade-in">
                <img src="${hotel.image}" alt="${hotel.name}" class="hotel-image">
                <div class="hotel-info">
                    <h3 class="hotel-name">${hotel.name}</h3>
                    <p class="hotel-location">📍 ${hotel.location}</p>
                    <div class="hotel-rating">
                        <span class="stars">${"★".repeat(Math.floor(hotel.rating))}${"☆".repeat(5 - Math.floor(hotel.rating))}</span>
                        <span>${hotel.rating}</span>
                    </div>
                    <div class="hotel-price">₹${hotel.price}/night</div>
                    <div class="hotel-buttons">
                        <button class="btn btn-primary" onclick="HotelBookingApp.viewHotelDetails(${hotel.id})">View Details</button>
                        <button class="btn btn-secondary" onclick="HotelBookingApp.quickBook(${hotel.id})">Book Now</button>
                        <button class="btn btn-outline" onclick="HotelBookingApp.toggleWatchlistFromList(${hotel.id})">Remove</button>
                    </div>
                </div>
            </div>
        `
      )
      .join("");
  },
  renderBookingHistory() {
    const container = document.getElementById("bookingHistoryContainer");
    if (this.bookings.length === 0) {
      container.innerHTML = `
                <div class="empty-state">
                    <div class="empty-state-icon">📋</div>
                    <h3>No bookings yet</h3>
                    <p>Your booking history will appear here</p>
                    <button class="btn btn-primary" onclick="HotelBookingApp.showPage('hotel-list')">Book Now</button>
                </div>
            `;
      return;
    }
    container.innerHTML = this.bookings
      .map(
        (booking) => `
            <div class="hotel-card fade-in" style="margin-bottom: 20px;">
                <img src="${booking.hotel.image}" alt="${booking.hotel.name}" class="hotel-image">
                <div class="hotel-info">
                    <h3 class="hotel-name">${booking.hotel.name}</h3>
                    <p class="hotel-location">📍 ${booking.hotel.location}</p>
                    <div class="price-row">
                        <span><strong>Booking ID:</strong> ${booking.bookingId}</span>
                        <span class="success" style="padding: 5px 10px; border-radius: 15px;">${booking.status}</span>
                    </div>
                    <div class="price-row">
                        <span>Check-in: ${booking.checkinDate}</span>
                        <span>Check-out: ${booking.checkoutDate}</span>
                    </div>
                    <div class="price-row">
                        <span>Room: ${booking.roomType}</span>
                        <span>Guests: ${booking.guestCount}</span>
                    </div>
                    <div class="hotel-price">Total Paid: ₹${booking.total}</div>
                    <p style="color: #666; font-size: 14px; margin-top: 10px;">
                        Booked on ${booking.bookingDate}
                    </p>
                </div>
            </div>
        `
      )
      .join("");
  },
  showAdminSection(e) {
    e.preventDefault();
    const section = e.target.getAttribute("data-section");
    document.querySelectorAll(".admin-nav-link").forEach((link) => {
      link.classList.remove("active");
    });
    e.target.classList.add("active");
    document.querySelectorAll(".admin-section").forEach((sec) => {
      sec.style.display = "none";
    });
    document.getElementById("admin-" + section).style.display = "block";
    switch (section) {
      case "hotels":
        this.renderAdminHotels();
        break;
      case "reviews":
        this.renderAdminReviews();
        break;
      case "bookings":
        this.renderAdminBookings();
        break;
    }
  },
  renderAdminData() {
    this.renderAdminHotels();
  },
  renderAdminHotels() {
    const tbody = document.getElementById("hotelsTableBody");
    tbody.innerHTML = this.hotels
      .map(
        (hotel) => `
            <tr>
                <td>${hotel.name}</td>
                <td>${hotel.location}</td>
                <td>₹${hotel.price}</td>
                <td>${hotel.rating}</td>
                <td>
                    <button class="btn btn-primary" onclick="HotelBookingApp.editHotel(${hotel.id})">Edit</button>
                    <button class="btn btn-secondary" onclick="HotelBookingApp.deleteHotel(${hotel.id})">Delete</button>
                </td>
            </tr>
        `
      )
      .join("");
  },
  renderAdminReviews() {
    const tbody = document.getElementById("reviewsTableBody");
    const allReviews = Object.entries(this.reviews).flatMap(
      ([hotelId, reviews]) => {
        const hotel = this.hotels.find((h) => h.id === parseInt(hotelId));
        return reviews.map((review) => ({
          ...review,
          hotelName: hotel ? hotel.name : "Unknown Hotel",
        }));
      }
    );
    if (allReviews.length === 0) {
      tbody.innerHTML = `
                <tr>
                    <td colspan="6" class="empty-state">
                        <div class="empty-state-icon">📝</div>
                        <p>No reviews available</p>
                    </td>
                </tr>
            `;
      return;
    }
    tbody.innerHTML = allReviews
      .map(
        (review) => `
            <tr>
                <td>${review.hotelName}</td>
                <td>${review.reviewerName}</td>
                <td>${review.rating}</td>
                <td>${review.reviewText}</td>
                <td>${review.date}</td>
                <td>
                    <button class="btn btn-secondary" onclick="HotelBookingApp.deleteReview(${review.id}, ${Object.keys(this.reviews).find((hotelId) =>
          this.reviews[hotelId].some((r) => r.id === review.id)
        )})">Delete</button>
                </td>
            </tr>
        `
      )
      .join("");
  },
  renderAdminBookings() {
    const tbody = document.getElementById("bookingsTableBody");
    if (this.bookings.length === 0) {
      tbody.innerHTML = `
                <tr>
                    <td colspan="7" class="empty-state">
                        <div class="empty-state-icon">📋</div>
                        <p>No bookings available</p>
                    </td>
                </tr>
            `;
      return;
    }
    tbody.innerHTML = this.bookings
      .map(
        (booking) => `
            <tr>
                <td>${booking.bookingId}</td>
                <td>${booking.hotel.name}</td>
                <td>${booking.guestName}</td>
                <td>${booking.checkinDate}</td>
                <td>${booking.checkoutDate}</td>
                <td>₹${booking.total}</td>
                <td>${booking.status}</td>
            </tr>
        `
      )
      .join("");
  },
  showHotelForm(hotel = null) {
    const form = document.getElementById("hotelForm");
    form.style.display = "block";
    if (hotel) {
      this.editingHotelId = hotel.id;
      document.getElementById("adminHotelName").value = hotel.name;
      document.getElementById("adminHotelLocation").value = hotel.location;
      document.getElementById("adminHotelPrice").value = hotel.price;
      document.getElementById("adminHotelRating").value = hotel.rating;
      document.getElementById("adminHotelDescription").value = hotel.description;
      document.getElementById("adminHotelImage").value = hotel.image;
      document.getElementById("adminHotelRooms").value = hotel.rooms
        .map((room) => `${room.type},${room.price},${room.description}`)
        .join(";");
    } else {
      this.editingHotelId = null;
      document.getElementById("adminHotelForm").reset();
    }
  },
  hideHotelForm() {
    document.getElementById("hotelForm").style.display = "none";
    document.getElementById("adminHotelForm").reset();
    this.editingHotelId = null;
  },
  saveHotel(e) {
    e.preventDefault();
    const roomsInput = document.getElementById("adminHotelRooms").value;
    let rooms = [];
    if (roomsInput) {
      rooms = roomsInput
        .split(";")
        .map((room) => {
          const [type, price, description] = room
            .split(",")
            .map((s) => s.trim());
          return { type, price: parseInt(price), description };
        })
        .filter((room) => room.type && !isNaN(room.price) && room.description);
    }
    if (rooms.length === 0) {
      rooms = [
        {
          type: "Standard Room",
          price: parseInt(document.getElementById("adminHotelPrice").value),
          description: "Standard room with basic amenities",
        },
      ];
    }
    const hotelData = {
      name: document.getElementById("adminHotelName").value,
      location: document.getElementById("adminHotelLocation").value,
      price: parseInt(document.getElementById("adminHotelPrice").value),
      rating: parseFloat(document.getElementById("adminHotelRating").value),
      description: document.getElementById("adminHotelDescription").value,
      image: document.getElementById("adminHotelImage").value,
      images: [
        document.getElementById("adminHotelImage").value,
        document.getElementById("adminHotelImage").value,
        document.getElementById("adminHotelImage").value,
      ],
      amenities: ["WiFi", "Restaurant", "Room Service"],
      rooms,
    };

    // Validate hotel data
    if (
      isNaN(hotelData.price) ||
      isNaN(hotelData.rating) ||
      hotelData.rating < 1 ||
      hotelData.rating > 5
    ) {
      const errorMsg = document.createElement("div");
      errorMsg.className = "error";
      errorMsg.textContent = "Please enter valid price and rating (1-5).";
      document.getElementById("adminHotelForm").prepend(errorMsg);
      setTimeout(() => errorMsg.remove(), 5000);
      return;
    }

    if (this.editingHotelId) {
      const index = this.hotels.findIndex((h) => h.id === this.editingHotelId);
      hotelData.id = this.editingHotelId;
      this.hotels[index] = hotelData;
    } else {
      hotelData.id = this.hotels.length + 1;
      this.hotels.push(hotelData);
    }

    this.saveToStorage();
    this.renderAdminHotels();
    this.hideHotelForm();
    const successMsg = document.createElement("div");
    successMsg.className = "success";
    successMsg.textContent = this.editingHotelId
      ? "Hotel updated successfully!"
      : "Hotel added successfully!";
    document
      .getElementById("admin-hotels")
      .insertBefore(successMsg, document.getElementById("hotelsTable"));
    setTimeout(() => successMsg.remove(), 3000);
  },
  editHotel(hotelId) {
    const hotel = this.hotels.find((h) => h.id === hotelId);
    this.showHotelForm(hotel);
  },
  deleteHotel(hotelId) {
    if (confirm("Are you sure you want to delete this hotel?")) {
      this.hotels = this.hotels.filter((h) => h.id !== hotelId);
      delete this.reviews[hotelId];
      this.bookings = this.bookings.filter((b) => b.hotel.id !== hotelId);
      this.watchlist = this.watchlist.filter((id) => id !== hotelId);
      this.saveToStorage();
      this.renderAdminHotels();
      const successMsg = document.createElement("div");
      successMsg.className = "success";
      successMsg.textContent = "Hotel deleted successfully!";
      document
        .getElementById("admin-hotels")
        .insertBefore(successMsg, document.getElementById("hotelsTable"));
      setTimeout(() => successMsg.remove(), 3000);
    }
  },
  deleteReview(reviewId, hotelId) {
    if (confirm("Are you sure you want to delete this review?")) {
      if (this.reviews[hotelId]) {
        this.reviews[hotelId] = this.reviews[hotelId].filter(
          (review) => review.id !== reviewId
        );
        if (this.reviews[hotelId].length === 0) {
          delete this.reviews[hotelId]; // Remove empty review arrays
        }
        this.saveToStorage();
        this.renderAdminReviews();
        const successMsg = document.createElement("div");
        successMsg.className = "success";
        successMsg.textContent = "Review deleted successfully!";
        document
          .getElementById("admin-reviews")
          .insertBefore(successMsg, document.getElementById("reviewsTable"));
        setTimeout(() => successMsg.remove(), 3000);
      } else {
        console.error(`No reviews found for hotel ID ${hotelId}`);
        const errorMsg = document.createElement("div");
        errorMsg.className = "error";
        errorMsg.textContent = "Error: Review not found.";
        document
          .getElementById("admin-reviews")
          .insertBefore(errorMsg, document.getElementById("reviewsTable"));
        setTimeout(() => errorMsg.remove(), 5000);
      }
    }
  },
};

// Initialize the app
HotelBookingApp.init();