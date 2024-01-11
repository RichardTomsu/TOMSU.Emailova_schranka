function openPopup(input) {
    var popup = document.getElementById(input);
    popup.style.display = "block";
}

// Function to close the pop-up
function closePopup(input) {
    var popup = document.getElementById(input);
    popup.style.display = "none";
}

function updateIn() {
    var selectedV = document.getElementById("for").value;
    if (document.getElementById("inputt").value != null) {
        document.getElementById("inputt").value += " " + selectedV;
    }
    else {
        document.getElementById("inputt").value = selectedV;
    }
}

const tab1B = document.getElementById("inbox-tab");
const tab2B = document.getElementById("sent-tab");
const tab3B = document.getElementById("spam-tab");
const tab4B = document.getElementById("delete-tab");

const cont1 = document.getElementById("inbox");
const cont2 = document.getElementById("sent");
const cont3 = document.getElementById("spam");
const cont4 = document.getElementById("delete");

tab1B.addEventListener("click", function () {
    cont1.style.display = "block";
    cont2.style.display = "none";
    cont3.style.display = "none";
    cont4.style.display = "none";
    tab1B.className = "nav-link show active";
    tab2B.className = "nav-link show";
    tab3B.className = "nav-link show";
    tab4B.className = "nav-link show";
})

tab2B.addEventListener("click", function () {
    cont2.style.display = "block";
    cont1.style.display = "none";
    cont3.style.display = "none";
    cont4.style.display = "none";
    tab2B.className = "nav-link show active";
    tab1B.className = "nav-link show";
    tab3B.className = "nav-link show";
    tab4B.className = "nav-link show";
})

tab3B.addEventListener("click", function () {
    cont3.style.display = "block";
    cont2.style.display = "none";
    cont1.style.display = "none";
    cont4.style.display = "none";
    tab3B.className = "nav-link show active";
    tab2B.className = "nav-link show";
    tab1B.className = "nav-link show";
    tab4B.className = "nav-link show";
})

tab4B.addEventListener("click", function () {
    cont4.style.display = "block";
    cont2.style.display = "none";
    cont3.style.display = "none";
    cont1.style.display = "none";
    tab4B.className = "nav-link show active";
    tab2B.className = "nav-link show";
    tab3B.className = "nav-link show";
    tab1B.className = "nav-link show";
})