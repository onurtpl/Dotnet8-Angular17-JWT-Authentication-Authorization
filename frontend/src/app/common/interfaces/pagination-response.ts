export interface PaginationResponse <T> {
    items: T[];
    totalCount: number;
    pageNumber: number;
    pageSize: number;
    isFirstPage: boolean;
    isLastPage: boolean;
}
