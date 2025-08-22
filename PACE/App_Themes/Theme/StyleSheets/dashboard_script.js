// Enhanced PACE Portal Script with improved navbar toggle functionality
document.addEventListener("DOMContentLoaded", () => {
    console.log("PACE Portal Script Loaded - Enhanced Version");

    // Initialize navigation functionality
    initializeNavigation();

    // Reinitialize after ASP.NET postbacks (for UpdatePanel compatibility)
    if (typeof Sys !== 'undefined' && Sys.WebForms && Sys.WebForms.PageRequestManager) {
        const prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {
            console.log("Postback completed - Reinitializing navigation");
            initializeNavigation();
        });
    }
});

function initializeNavigation() {
    // --- Mobile Navigation Toggle --- //
    const mobileNavToggle = document.querySelector(".mobile-nav-toggle");
    const dashboardNav = document.querySelector(".dashboard-nav");

    if (mobileNavToggle && dashboardNav) {
        // Remove existing event listeners to prevent duplicates
        const newToggleButton = mobileNavToggle.cloneNode(true);
        mobileNavToggle.parentNode.replaceChild(newToggleButton, mobileNavToggle);

        // Add fresh event listener
        newToggleButton.addEventListener("click", function (event) {
            event.preventDefault(); // Prevent default button behavior
            event.stopPropagation(); // Stop event bubbling

            console.log("Mobile nav toggle clicked");

            // Toggle the navigation
            dashboardNav.classList.toggle("open");

            // Update icon
            const icon = newToggleButton.querySelector("i");
            if (icon) {
                if (dashboardNav.classList.contains("open")) {
                    icon.classList.remove("fa-bars");
                    icon.classList.add("fa-times");
                } else {
                    icon.classList.remove("fa-times");
                    icon.classList.add("fa-bars");
                }
            }

            console.log("Navigation state:", dashboardNav.classList.contains("open") ? "open" : "closed");
        });

        // Close navigation when clicking outside (improved)
        document.addEventListener("click", function (event) {
            // Check if click is outside navigation and toggle button
            if (!dashboardNav.contains(event.target) &&
                !newToggleButton.contains(event.target) &&
                dashboardNav.classList.contains("open")) {

                console.log("Clicked outside navigation - closing");
                dashboardNav.classList.remove("open");

                // Reset icon
                const icon = newToggleButton.querySelector("i");
                if (icon) {
                    icon.classList.remove("fa-times");
                    icon.classList.add("fa-bars");
                }
            }
        });

        // Close navigation on window resize to desktop size
        window.addEventListener("resize", function () {
            if (window.innerWidth > 1024 && dashboardNav.classList.contains("open")) {
                console.log("Resized to desktop - closing mobile nav");
                dashboardNav.classList.remove("open");

                // Reset icon
                const icon = newToggleButton.querySelector("i");
                if (icon) {
                    icon.classList.remove("fa-times");
                    icon.classList.add("fa-bars");
                }
            }
        });
    }

    // --- Mobile Accordion Menu Logic (Enhanced) --- //
    const navItemsWithSubmenus = document.querySelectorAll(".dashboard-nav .nav-item.has-megamenu, .dashboard-nav .nav-item.dropdown");

    navItemsWithSubmenus.forEach(item => {
        const link = item.querySelector(".nav-link, .dropdown-toggle");
        if (link) {
            // Remove existing event listeners
            const newLink = link.cloneNode(true);
            link.parentNode.replaceChild(newLink, link);

            newLink.addEventListener("click", function (event) {
                // Check if we are in mobile view (hamburger is visible)
                const mobileToggle = document.querySelector(".mobile-nav-toggle");
                if (mobileToggle && window.getComputedStyle(mobileToggle).display !== 'none') {
                    event.preventDefault(); // Prevent default link behavior only in mobile accordion mode
                    event.stopPropagation(); // Prevent event bubbling

                    console.log("Mobile submenu toggle clicked");
                    item.classList.toggle("open");

                    // Optional: Close other open submenus for cleaner accordion
                    navItemsWithSubmenus.forEach(otherItem => {
                        if (otherItem !== item && otherItem.classList.contains('open')) {
                            otherItem.classList.remove('open');
                        }
                    });
                }
            });
        }
    });

    // --- Enhanced Form Interaction Handling --- //
    // Prevent navigation toggle conflicts with form submissions
    const forms = document.querySelectorAll('form');
    forms.forEach(form => {
        form.addEventListener('submit', function (event) {
            console.log("Form submission detected");
            // Don't close navigation on form submit to maintain user context
        });
    });

    // Handle ASP.NET button clicks that might cause postbacks
    const aspNetButtons = document.querySelectorAll('input[type="submit"], .btn, .search_button, .logout-btn');
    aspNetButtons.forEach(button => {
        button.addEventListener('click', function (event) {
            console.log("ASP.NET button clicked:", this.className);
            // Allow the button click to proceed normally
            // Navigation state will be preserved and reinitialized after postback
        });
    });

    // --- Existing Logout Logic (Enhanced) --- //
    const logoutLinks = document.querySelectorAll(".logout-link, .logout-btn");
    logoutLinks.forEach(logoutElement => {
        // Remove existing event listeners
        const newLogoutElement = logoutElement.cloneNode(true);
        logoutElement.parentNode.replaceChild(newLogoutElement, logoutElement);

        newLogoutElement.addEventListener("click", function (event) {
            console.log("Logout clicked");
            // For ASP.NET buttons, allow default behavior (postback)
            if (this.tagName.toLowerCase() === 'a') {
                event.preventDefault();
                window.location.href = "login.html";
            }
            // For ASP.NET server controls, let them handle the postback
        });
    });

    // --- Existing Card Link Logic (if on dashboard) --- //
    const cardLinks = document.querySelectorAll(".card-link");
    if (cardLinks.length > 0) {
        cardLinks.forEach(link => {
            // Remove existing event listeners
            const newLink = link.cloneNode(true);
            link.parentNode.replaceChild(newLink, link);

            newLink.addEventListener("click", function (event) {
                event.preventDefault();
                const moduleName = this.closest(".dashboard-card").querySelector("h2").textContent;
                console.log(`Navigating to ${moduleName} module`);
                // In a real application, navigate to the respective module page
            });
        });
    }

    // --- CAPTCHA Logic (if on change password page) --- //
    initializeCaptcha();

    console.log("Navigation initialization completed");
}

function initializeCaptcha() {
    const captchaTextElement = document.getElementById('captchaText');
    const captchaInputElement = document.getElementById('captchaInput');
    const refreshButton = document.getElementById('refreshCaptcha');
    const changePasswordForm = document.getElementById('changePasswordForm');
    let currentCaptcha = '';

    function generateCaptcha() {
        const chars = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
        let captcha = '';
        for (let i = 0; i < 6; i++) {
            captcha += chars.charAt(Math.floor(Math.random() * chars.length));
        }
        currentCaptcha = captcha;
        if (captchaTextElement) {
            captchaTextElement.textContent = captcha;
        }
        if (captchaInputElement) {
            captchaInputElement.value = ''; // Clear input on refresh
        }
    }

    if (captchaTextElement && captchaInputElement && refreshButton && changePasswordForm) {
        // Remove existing event listeners
        const newRefreshButton = refreshButton.cloneNode(true);
        refreshButton.parentNode.replaceChild(newRefreshButton, refreshButton);

        const newChangePasswordForm = changePasswordForm.cloneNode(true);
        changePasswordForm.parentNode.replaceChild(newChangePasswordForm, changePasswordForm);

        newRefreshButton.addEventListener('click', generateCaptcha);

        newChangePasswordForm.addEventListener('submit', function (event) {
            event.preventDefault(); // Prevent default form submission

            const enteredCaptcha = this.querySelector('#captchaInput').value;
            const newPassword = this.querySelector('#newPassword').value;
            const confirmPassword = this.querySelector('#confirmPassword').value;

            // Basic validation
            if (newPassword !== confirmPassword) {
                alert('New password and confirm password do not match.');
                generateCaptcha(); // Refresh captcha on error
                return;
            }

            if (enteredCaptcha !== currentCaptcha) {
                alert('CAPTCHA verification failed. Please try again.');
                generateCaptcha(); // Refresh captcha on error
            } else {
                // CAPTCHA is correct
                alert('CAPTCHA verified! Password change submitted (simulation).');
                this.reset();
                generateCaptcha();
            }
        });

        // Initial CAPTCHA generation
        generateCaptcha();
    }
}

// Utility function to debug navigation state
function debugNavigationState() {
    const dashboardNav = document.querySelector(".dashboard-nav");
    const mobileToggle = document.querySelector(".mobile-nav-toggle");

    console.log("=== Navigation Debug Info ===");
    console.log("Dashboard Nav Classes:", dashboardNav ? dashboardNav.className : "Not found");
    console.log("Mobile Toggle Display:", mobileToggle ? window.getComputedStyle(mobileToggle).display : "Not found");
    console.log("Window Width:", window.innerWidth);
    console.log("Navigation Open:", dashboardNav ? dashboardNav.classList.contains("open") : false);
    console.log("============================");
}

// Make debug function available globally for troubleshooting
window.debugNavigationState = debugNavigationState;

