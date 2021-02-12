export default class Countdown {
  constructor(futureDate) {
    this.futureDate = futureDate;
  }
  get _currentDate() {
    return new Date();
  }
  get _futureDate() {
    return new Date(this.futureDate);
  }
  get _timeStampDiff() {
    //Return de difference between furureDate and currentDate in milliseconds...
    return this._futureDate.getTime() - this._currentDate.getTime();
  }
  get totalDays() {
    //Calc: timeStampDiff / (24 hour/day * 60 min/hour * 60 sec/min * 1000 milliseconds);
    //Math.floor() round to down
    return Math.floor(this._timeStampDiff / (24 * 60 * 60 * 1000));
  }
  get totalHours() {
    return Math.floor(this._timeStampDiff / (60 * 60 * 1000));
  }
  get totalMinutes() {
    return Math.floor(this._timeStampDiff / (60 * 1000));
  }
  get totalSeconds() {
    return Math.floor(this._timeStampDiff / 1000);
  }
  get total() {
    const days = this.totalDays;
    const hours = this.totalHours % 24;
    const minutes = this.totalMinutes % 60;
    const seconds = this.totalSeconds % 60;

    return {
      days,
      hours,
      minutes,
      seconds,
    };
  }
}
