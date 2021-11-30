function attachEventsListeners() {
    document.getElementById('daysBtn').addEventListener('click', onClick);
    document.getElementById('hoursBtn').addEventListener('click', onClick);
    document.getElementById('minutesBtn').addEventListener('click', onClick);
    document.getElementById('secondsBtn').addEventListener('click', onClick);

    
    let days = document.getElementById('days');
    let hours = document.getElementById('hours');
    let minutes = document.getElementById('minutes');
    let seconds = document.getElementById('seconds');

    function onClick(ev){
        let input = ev.target.parentElement.querySelector('input[type="text"]')
        
        let time = convert(input.value, input.id);

        days.value = time.days;
        hours.value = time.hours;
        minutes.value = time.minutes;
        seconds.value = time.seconds;
    }

    const ratios = {
        days: 1,
        hours: 24,
        minutes:1440,
        seconds: 86400
    };

    function convert(value,unit){
        let inDays = value / ratios[unit];
        
        return {
            days: inDays,
            hours: inDays * ratios.hours,
            minutes: inDays * ratios.minutes,
            seconds: inDays * ratios.seconds
        };
    }
}