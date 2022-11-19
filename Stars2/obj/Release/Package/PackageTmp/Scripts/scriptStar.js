window.onload = function() {
  $('.navp > li').on('mouseenter', function(){
    $(this).find('.menu_item_hover').toggleClass('menu_item_hover_show');
  });
  $('.navp > li').on('mouseleave', function(){
    $(this).find('.menu_item_hover').toggleClass('menu_item_hover_show');
  });
}
