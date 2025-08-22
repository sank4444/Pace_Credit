export interface Bill {
  id: number;
  billNumber: string;
  amount: number;
  dueDate: string;
  status: 'Paid' | 'Unpaid' | 'Overdue';
}

export const bills: Bill[] = [
  { id: 1, billNumber: 'B-2023-001', amount: 150.75, dueDate: '2023-10-31', status: 'Paid' },
  { id: 2, billNumber: 'B-2023-002', amount: 200.00, dueDate: '2023-11-15', status: 'Unpaid' },
  { id: 3, billNumber: 'B-2023-003', amount: 75.50, dueDate: '2023-09-30', status: 'Overdue' },
  { id: 4, billNumber: 'B-2023-004', amount: 300.25, dueDate: '2023-11-30', status: 'Unpaid' },
  { id: 5, billNumber: 'B-2023-005', amount: 125.00, dueDate: '2023-10-15', status: 'Paid' },
];
