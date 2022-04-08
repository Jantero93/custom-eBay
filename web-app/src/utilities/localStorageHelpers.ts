import { addHourToCurrentTime, isBeforeCurrentTime } from './dateHelpers';

const dataKey = 'logging-data';

export const clearLoginLocalStorage = () =>
  localStorage.removeItem('logging-data');

export const isLoggingExpired = (): boolean => {
  const dataJSON = localStorage.getItem(dataKey);

  if (dataJSON === null) return true;

  const data = JSON.parse(dataJSON);
  return isBeforeCurrentTime(data.expires);
};

export const saveLoginLocalStorage = (username: string) => {
  const LoggingData = {
    username,
    expires: addHourToCurrentTime()
  };

  const DataJSON = JSON.stringify(LoggingData);

  localStorage.setItem(dataKey, DataJSON);
};
