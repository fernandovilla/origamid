
const DateTimeToTextShort = (value) => {
  if (value !== undefined) {    
    try {
        const date = new Date(value);

        if (date != undefined){
            return new Intl.DateTimeFormat('pt-BR', {dateStyle: 'short'}).format(date);
        }    

    } catch (e) {
      console.log(e);
    }
  }
};

const GetCurrentDateTimeZone = () => {  
  var date = new Date();
  var year = date.getFullYear();
  var month = date.getMonth();
  var day = date.getDate();
  var hour = date.getHours();
  var min = date.getMinutes();
  var sec = date.getSeconds();
  
  var now_utc = Date.UTC(year, month, day, hour, min, sec, 0);
  var date_utc = new Date(now_utc);
  
  return date_utc.toISOString();
}

export { DateTimeToTextShort, GetCurrentDateTimeZone}