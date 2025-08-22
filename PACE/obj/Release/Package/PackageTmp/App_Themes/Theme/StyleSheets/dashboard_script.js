document.addEventListener("DOMContentLoaded", () => {
    console.log("PACE Portal Script Loaded");

    // --- Mobile Navigation Toggle --- //
    const mobileNavToggle = document.querySelector(".mobile-nav-toggle");
    const dashboardNav = document.querySelector(".dashboard-nav");

    if (mobileNavToggle && dashboardNav) {
        mobileNavToggle.addEventListener("click", () => {
            dashboardNav.classList.toggle("open");
            // Optional: Change icon on toggle
            const icon = mobileNavToggle.querySelector("i");
            if (icon) {
                icon.classList.toggle("fa-bars");
                icon.classList.toggle("fa-times");
            }
        });
    }

    // --- Mobile Accordion Menu Logic --- //
    const navItemsWithSubmenus = document.querySelectorAll(".dashboard-nav .nav-item.has-megamenu, .dashboard-nav .nav-item.dropdown");

    navItemsWithSubmenus.forEach(item => {
        const link = item.querySelector(".nav-link, .dropdown-toggle");
        if (link) {
            link.addEventListener("click", function (event) {
                // Check if we are in mobile view (hamburger is visible)
                if (window.getComputedStyle(mobileNavToggle).display !== 'none') {
                    event.preventDefault(); // Prevent default link behavior only in mobile accordion mode
                    item.classList.toggle("open");

                    // Close other open submenus (optional, for cleaner accordion)
                    // navItemsWithSubmenus.forEach(otherItem => {
                    //     if (otherItem !== item && otherItem.classList.contains('open')) {
                    //         otherItem.classList.remove('open');
                    //     }
                    // });
                }
            });
        }
    });

    // --- Existing Logout Logic --- //
    const logoutLink = document.querySelector(".logout-link"); // Target the link itself
    if (logoutLink) {
        logoutLink.addEventListener("click", (event) => {
            event.preventDefault(); // Prevent default link behavior
            console.log("Logout link clicked");
            // Redirect back to the login page
            window.location.href = "login.html";
        });
    }

    // --- Existing Card Link Logic (if on dashboard) --- //
    const cardLinks = document.querySelectorAll(".card-link");
    if (cardLinks.length > 0) {
        cardLinks.forEach(link => {
            link.addEventListener("click", (event) => {
                event.preventDefault();
                const moduleName = link.closest(".dashboard-card").querySelector("h2").textContent;
                alert(`Navigating to ${moduleName} module (simulation).`);
                // In a real application, navigate to the respective module page
            });
        });
    }

    // --- CAPTCHA Logic (if on change password page) --- //
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
        refreshButton.addEventListener('click', generateCaptcha);

        changePasswordForm.addEventListener('submit', function (event) {
            event.preventDefault(); // Prevent default form submission

            const enteredCaptcha = captchaInputElement.value;
            const newPassword = document.getElementById('newPassword').value;
            const confirmPassword = document.getElementById('confirmPassword').value;

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
                changePasswordForm.reset();
                generateCaptcha();
            }
        });

        // Initial CAPTCHA generation
        generateCaptcha();
    }

});

