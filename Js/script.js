$(document).ready(function() {
$('#mobile_btn').on('click', function() {

    $('#menu_mobile').toggleClass('active');
    $('#mobile_btn').find('i').toggleClass('fa-x');
});

const sections = $('section');
const navItens = $('.nav_item')

$(window).on('scroll',function(){

    const header= $('header');
    let activeSectionIndex=0;
    const scrollPosition= $(window).scrollTop() - header.outerHeight();
    
    if(scrollPosition <=0){
        header.css('box-shadow', 'none')
    }else{
        header.css('box-shadow','5px 1 px 5px rgba(0,0,0,0.1)');
    }
    sections.each(function(i){
        const section = $(this);
        const Sectiontop = section.offset().top - 96;
        const sectionBottom = Sectiontop + section.outerHeight();
        if(scrollPosition >= Sectiontop && scrollPosition < sectionBottom){
            activeSectionIndex = i;
            return false;
        }
    })
    navItens.removeClass('active');
    $(navItens[activeSectionIndex]).addClass('active');

});

ScrollReveal().reveal('#cta',{
origin: 'left',
duration :2000,
distance:'20%'

});

ScrollReveal().reveal('.shoe',{
    origin: 'left',
    duration :2000,
    distance:'20%'
    
    });

    ScrollReveal().reveal('#testimonial-shoe',{
        origin: 'left',
        duration :2000,
        distance:'20%'
        
        });

        ScrollReveal().reveal('#banner',{
            origin: 'right',
            duration :2000,
            distance:'20%'
            
            });

            ScrollReveal().reveal('.feedback',{
                origin: 'right',
                duration :2000,
                distance:'20%'
                
                });
    
                ScrollReveal().reveal('#footer-itens',{
                    origin: 'right',
                    duration :2000,
                    distance:'20%'
                    
                    });

                    ScrollReveal().reveal('.fa-solid fa-shoe-prints',{
                        origin: 'left',
                        duration :2000,
                        distance:'20%'
                        
                        });
        
});