export const getOffsetTop = element => {
    let offsetTop = 0;
    while(element) {
      offsetTop += element.offsetTop;
      element = element.offsetParent;
    }
    return offsetTop;
  }


export const smoothScroll = (ref) => {
    let top = getOffsetTop(ref.current);
    window.scrollTo({ behavior: 'smooth', top:  top})  
}