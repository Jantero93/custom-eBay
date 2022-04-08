import moment from 'moment';

export const addHourToCurrentTime = (): string =>
  moment().add(1, 'h').toISOString();

export const isBeforeCurrentTime = (time: string) => moment(time).isBefore();
