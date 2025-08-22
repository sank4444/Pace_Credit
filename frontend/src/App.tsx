import { ThemeProvider, createTheme } from '@mui/material/styles';
import CssBaseline from '@mui/material/CssBaseline';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Layout from './components/Layout';
import MemberInformation from './components/MemberInformation';
import BillEnquiry from './components/BillEnquiry';
import Claims from './components/Claims';
import Typography from '@mui/material/Typography';

const darkTheme = createTheme({
  palette: {
    mode: 'dark',
  },
});

function Home() {
  return (
    <>
      <Typography variant="h4" gutterBottom>
        Welcome to the new PACE application!
      </Typography>
      <Typography paragraph>
        Use the navigation menu on the left to explore the different features.
      </Typography>
    </>
  );
}

function App() {
  return (
    <ThemeProvider theme={darkTheme}>
      <CssBaseline />
      <BrowserRouter>
        <Layout>
          <Routes>
            <Route path="/" element={<Home />} />
            <Route path="/members" element={<MemberInformation />} />
            <Route path="/bills" element={<BillEnquiry />} />
            <Route path="/claims" element={<Claims />} />
          </Routes>
        </Layout>
      </BrowserRouter>
    </ThemeProvider>
  )
}

export default App
