// sticky nav bar
$(window).scroll(function () {
  console.log("22");
  if ($(window).scrollTop()) {
    $(".nav-bar").addClass("sticky");
  } else {
    $(".nav-bar").removeClass("sticky");
  }
});

// mobile nav bar
$("#mobile-nav").click(function () {
  if ($("#sidebar").hasClass("hidden")) {
    $(".sidebar").removeClass("hidden");
  } else {
    $(".sidebar").addClass("hidden");
  }
});

//pop up box
const modal = document.querySelector(".modal");
const overlay = document.querySelector(".overlay");
const btnShowModal = document.querySelector("#showModal");
const btnCloseModal = document.querySelector(".close-modal");

const showModal = function () {
  console.log("22");
  modal.classList.remove("hidden");
  overlay.classList.remove("hidden");
};

const closeModal = function () {
  modal.classList.add("hidden");
  overlay.classList.add("hidden");
};

btnShowModal.addEventListener("click", showModal);
btnCloseModal.addEventListener("click", closeModal);
overlay.addEventListener("click", closeModal);
