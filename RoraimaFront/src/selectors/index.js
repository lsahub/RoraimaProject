export const getOffsetTop = element => {
    let offsetTop = 0;
    while(element) {
      offsetTop += element.offsetTop;
      element = element.offsetParent;
    }
    return offsetTop;
  }


export const smoothScroll = (ref) => {
    let top = getOffsetTop(ref.current) - 25;
    window.scrollTo({ behavior: 'smooth', top:  top})  
}

export const declOfNum = (number, titles) => {  
    const cases = [2, 0, 1, 1, 1, 2];  
    return titles[ (number%100>4 && number%100<20)? 2 : cases[(number%10<5)?number%10:5] ];  
}