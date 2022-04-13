export const conditionIntToString = (condition: number): string => {
  switch (condition) {
    case 0:
      return 'New';
    case 1:
      return 'Good';
    case 2:
      return 'Fair';
    case 3:
      return 'Poor';
    default:
      return 'Unknown';
  }
};
