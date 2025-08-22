export interface Claim {
  id: number;
  claimNumber: string;
  type: string;
  amount: number;
  date: string;
  status: 'Approved' | 'Rejected' | 'Pending';
}

export const claims: Claim[] = [
  { id: 1, claimNumber: 'C-2023-001', type: 'Medical', amount: 500.00, date: '2023-10-20', status: 'Approved' },
  { id: 2, claimNumber: 'C-2023-002', type: 'Dental', amount: 150.00, date: '2023-10-25', status: 'Pending' },
  { id: 3, claimNumber: 'C-2023-003', type: 'Vision', amount: 200.00, date: '2023-11-01', status: 'Rejected' },
  { id: 4, claimNumber: 'C-2023-004', type: 'Medical', amount: 750.00, date: '2023-11-05', status: 'Pending' },
  { id: 5, claimNumber: 'C-2023-005', type: 'Dental', amount: 250.00, date: '2023-11-10', status: 'Approved' },
];
