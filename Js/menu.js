$(document).ready(function() {
    $('#mobile_btn').on('click', function() {
    
        $('#menu_mobile').toggleClass('active');
        $('#mobile_btn').find('i').toggleClass('fa-x');
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
                






});