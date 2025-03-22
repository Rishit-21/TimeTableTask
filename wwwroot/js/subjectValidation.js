document.addEventListener("DOMContentLoaded", function () {
    let totalHours = parseInt(document.getElementById("hiddenTotalHours").value);
    let remainingHoursDisplay = document.getElementById("remainingHours");
    let progressBar = document.getElementById("progressBar");
    let submitButton = document.getElementById("submitButton");
    let hourInputs = document.querySelectorAll(".subject-hours");

    function updateRemainingHours() {
        let allocatedHours = 0;

        hourInputs.forEach(input => {
            let value = parseInt(input.value) || 0;
            allocatedHours += value;
        });

        let remainingHours = totalHours - allocatedHours;
        let percentage = (remainingHours / totalHours) * 100;
        percentage = Math.max(0, percentage); // Prevents negative width

        // Update progress bar & text
        progressBar.style.width = `${percentage}%`;
        remainingHoursDisplay.textContent = remainingHours;
        progressBar.textContent = `Remaining: ${remainingHours}`;

        // Change progress bar color based on remaining hours
        if (remainingHours < 0) {
            progressBar.classList.remove("bg-success");
            progressBar.classList.add("bg-danger");
            submitButton.disabled = true;
        } else if (remainingHours === 0) {
            progressBar.classList.remove("bg-danger");
            progressBar.classList.add("bg-success");
            submitButton.disabled = false;
        } else {
            progressBar.classList.add("bg-warning");
            submitButton.disabled = true;
        }

        // Disable empty subject fields when total hours are reached
        hourInputs.forEach(input => {
            if (remainingHours === 0 && input.value === "") {
                input.disabled = true;
            } else {
                input.disabled = false;
            }
        });
    }

    // Attach event listeners to all hour inputs
    hourInputs.forEach(input => {
        input.addEventListener("input", updateRemainingHours);
    });

    // Initial check on page load
    updateRemainingHours();
});
