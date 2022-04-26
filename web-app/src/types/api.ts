export interface Pager<T> {
  currentPage: number;
  hasNextPage: boolean;
  hasPreviousPage: boolean;
  items: T[];
  pageSize: number;
  totalPages: number;
  totalCount: number;
}
