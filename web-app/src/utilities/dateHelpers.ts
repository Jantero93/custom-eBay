import moment from 'moment';

export const addHourToCurrentTime = (): string =>
  moment().add(1, 'h').toISOString();

export const formatDate = (format: string, date?: string | number): string =>
  date ? moment(date).format(format) : moment().format(format);

export const isBeforeCurrentTime = (time: string) => moment(time).isBefore();
