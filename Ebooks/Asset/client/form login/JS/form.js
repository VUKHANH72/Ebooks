const $ = document.querySelector.bind(document)
const $$ = document.querySelectorAll.bind(document)

function handleClickPassWordChange() {
    const btnShowPassWord = $('.form-group-password-show')
    const btnHidePassWord = $('.form-group-password-hide')
    const inputPassWord = $('.form-control-password')

    const btnShowPassWord1 = $('.form-group-password-show1')
    const btnHidePassWord1 = $('.form-group-password-hide1')
    const inputPassWord1 = $('.form-control-password1')

    const btnShowPassWord2 = $('.form-group-password-show2')
    const btnHidePassWord2 = $('.form-group-password-hide2')
    const inputPassWord2 = $('.form-control-password2')

    //show password at login form input
    btnShowPassWord.addEventListener('click', () => {
      btnShowPassWord.style.display = 'none'
      btnHidePassWord.style.display = 'block'
      inputPassWord.type = 'text'
    })

    btnHidePassWord.addEventListener('click', () => {
      btnHidePassWord.style.display = 'none'
      btnShowPassWord.style.display = 'block'
      inputPassWord.type = 'password'
    })
    //show password at Register form password input
    btnShowPassWord1.addEventListener('click', () => {
      btnShowPassWord1.style.display = 'none'
      btnHidePassWord1.style.display = 'block'
      inputPassWord1.type = 'text'
    })

    btnHidePassWord1.addEventListener('click', () => {
      btnHidePassWord1.style.display = 'none'
      btnShowPassWord1.style.display = 'block'
      inputPassWord1.type = 'password'
    })
    //show password at Register form checked password input
    btnShowPassWord2.addEventListener('click', () => {
      btnShowPassWord2.style.display = 'none'
      btnHidePassWord2.style.display = 'block'
      inputPassWord2.type = 'text'
    })

    btnHidePassWord2.addEventListener('click', () => {
      btnHidePassWord2.style.display = 'none'
      btnShowPassWord2.style.display = 'block'
      inputPassWord2.type = 'password'
    })
}

handleClickPassWordChange()
