import outsideClick from "./outsideclick.js";

export default function initDropdownMenu() {
  const dropdownMenus = document.querySelectorAll("[data-dropdown]");

  dropdownMenus.forEach((menu) => {
    //touchstart é semelhante ao click, porém sem delay e funciona em mobile
    ["touchstart", "click"].forEach((i) => {
      menu.addEventListener(i, handleClick);
    });
  });

  function handleClick(event) {
    event.preventDefault();

    this.classList.add("active");
    //prepara o menu para sumir quando usuário clicar fora
    outsideClick(this, ["touchstart", "click"], () => {
      this.classList.remove("active");
    });
  }
}
