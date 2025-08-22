export interface Member {
  id: number;
  name: string;
  policyNumber: string;
  status: 'Active' | 'Inactive' | 'Pending';
  email: string;
}

export const members: Member[] = [
  { id: 1, name: 'John Doe', policyNumber: 'P12345', status: 'Active', email: 'john.doe@example.com' },
  { id: 2, name: 'Jane Smith', policyNumber: 'P67890', status: 'Active', email: 'jane.smith@example.com' },
  { id: 3, name: 'Peter Jones', policyNumber: 'P24680', status: 'Inactive', email: 'peter.jones@example.com' },
  { id: 4, name: 'Mary Williams', policyNumber: 'P13579', status: 'Pending', email: 'mary.williams@example.com' },
  { id: 5, name: 'David Brown', policyNumber: 'P98765', status: 'Active', email: 'david.brown@example.com' },
];
