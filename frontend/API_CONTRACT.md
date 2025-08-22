# API Contract

This document outlines the API endpoints and data structures that the React frontend expects.

## Endpoints

### `GET /api/members`

Returns a list of all members.

**Response Body:**

An array of member objects.

**Member Interface:**

```typescript
export interface Member {
  id: number;
  name: string;
  policyNumber: string;
  status: 'Active' | 'Inactive' | 'Pending';
  email: string;
}
```

### `GET /api/bills`

Returns a list of all bills.

**Response Body:**

An array of bill objects.

**Bill Interface:**

```typescript
export interface Bill {
  id: number;
  billNumber: string;
  amount: number;
  dueDate: string;
  status: 'Paid' | 'Unpaid' | 'Overdue';
}
```

### `GET /api/claims`

Returns a list of all claims.

**Response Body:**

An array of claim objects.

**Claim Interface:**

```typescript
export interface Claim {
  id: number;
  claimNumber: string;
  type: string;
  amount: number;
  date: string;
  status: 'Approved' | 'Rejected' | 'Pending';
}
```
