using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace One_Stop_Tourist_identity_Application
{
    public partial class oneStopTouristApplication : Form
    {
        public oneStopTouristApplication()
        {
            InitializeComponent();
        }
        // The Sum method accepts three decimal arguments
        // and returns the sum of the arguments.
        private decimal Sum(decimal num1, decimal num2, decimal num3)
        {
            return num1 + num2 + num3;
        }

        private decimal Multiplication(decimal num1, int num2)
        {
            return num1 * num2;
        }

        private void SetToZero(ref decimal number)
        {
            number = 0;
        }
        private void CountVariable(ref int count1, int count2)
        {
            count1 = count2;
        }

        private void getPriceFromAnnouncedListPriceButton_Click(object sender, EventArgs e)
        {
            // To hold the name of an airlines and its fare temporary
            string airlineFares;

            if (airLineFaresListBox.SelectedIndex != -1)
            {
                // Get the selected airline item's fare.
                airlineFares = airLineFaresListBox.SelectedItem.ToString();

                // Determine the ailineFare
                switch (airlineFares)
                {
                    case "Air (2I)":
                        outputLabelFareOnThisFlight.Text = "14000";
                        break;
                    case "40-Mile Air (Q5)":
                        outputLabelFareOnThisFlight.Text = "1000";
                        break;
                    case "Air Co (AQ)":
                        outputLabelFareOnThisFlight.Text = "750";
                        break;
                    case "Advanced Air (AN)":
                        outputLabelFareOnThisFlight.Text = "1000";
                        break;
                    case "Aegean Airlines (A3)":
                        outputLabelFareOnThisFlight.Text = "600";
                        break;
                    case "Aer Lingus (EI)":
                        outputLabelFareOnThisFlight.Text = "900";
                        break;
                    default:
                        MessageBox.Show("Airline must be either in listing or pricing process");
                        break;

                }

            }
            else
            {
                // Show error message when no item is selected
                MessageBox.Show("Select an Airline and Airline Fare.");

            }
        }


        private void getPriceFromAnnouncedListPrice_Click(object sender, EventArgs e)
        {


            // To hold the name of a lodging and its fare
            string lodgingFares;

            if (roomsFaresListBox.SelectedIndex != -1)
            {
                // Get the selected item.
                lodgingFares = roomsFaresListBox.SelectedItem.ToString();


                // Determine the lodgingFare
                switch (lodgingFares)
                {
                    case "Ritz - Carlton Hotel":
                        outputLabelFareOnThisRoom.Text = "3000";
                        break;
                    case "Aman Resorts":
                        outputLabelFareOnThisRoom.Text = "400";
                        break;
                    case "Marriott International":
                        outputLabelFareOnThisRoom.Text = "4000";
                        break;
                    case "Hilton":
                        outputLabelFareOnThisRoom.Text = "800";
                        break;
                    case "Hyatt Hotel":
                        outputLabelFareOnThisRoom.Text = "1200";
                        break;
                    case "Wyndham Lodging":
                        outputLabelFareOnThisRoom.Text = "400";
                        break;
                    default:
                        MessageBox.Show("Hotel or Lodging place must be either in listing or pricing process");
                        break;
                }
            }
            else
            {
                // Show error message when no item is selected
                MessageBox.Show("Select a Room or a Room Fare.");
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void getPriceFromAnnouncedSiteListPriceButton_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(outputLabelFareOnThisRoom.Text, out decimal lodgingFares))
            {
                if (decimal.TryParse(budgetValueTextBox.Text, out decimal budgetValue))
                {
                    if (lodgingFares >= 0 && lodgingFares <= budgetValue)
                    {
                        // Continue to process the input.
                        // To hold the name of an eTour fit to Tourism Category, country and fare fit to budget
                        string eTourTidesSeeing;

                        if (siteSeeingFaresListBox.SelectedIndex != -1)
                        {
                            if (siteSeeingFaresListBox.SelectedIndex == 1)
                            {
                                // Get the selected item.
                                eTourTidesSeeing = siteSeeingFaresListBox.SelectedItem.ToString();
                            }
                            else
                            {
                                eTourTidesSeeing = siteSeeingFaresListBox.SelectedItem.ToString();
                                outputBookedSightSeeingGatesLabel.Text = eTourTidesSeeing;
                            }

                            // Determine the sightseeing fare
                            switch (eTourTidesSeeing)
                            {
                                case "eTours Tides Tourism Attraction, Mont Saint, Michel: France: Airport Paris-Charles De Gaulle(CDG)":
                                    outputLabelFareOnThisTouristSite.Text = "3000";
                                    break;
                                case "eTours Tides Tourism AttractionMont Saint, Michel Bay: Canada: Airport Montreal Mirabel Intl Apt(YMX)":
                                    outputLabelFareOnThisTouristSite.Text = "400";
                                    break;
                                case "eTour Onboard Water Sports via Ships Attraction, Seabourn Odyssey: Point of Sail Western Mediterranean Cruise":
                                    outputLabelFareOnThisTouristSite.Text = "3000";
                                    break;
                                case "eTour Onboard Water Sports via Ships Attraction, Oasis of the Sea: Point of Sail Western Mediterranean Cruise":
                                    outputLabelFareOnThisTouristSite.Text = "400";
                                    break;
                                default:
                                    MessageBox.Show("SightSeeing Location must be either in listing or pricing process");
                                    break;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Insufficient fit to budget tour.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("The budget selection must either increase or select other items on the previous tourism sector.");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid budget value. Please ensure the budget is a valid number.");
                }
            }
            else
            {
                MessageBox.Show("Invalid lodging fare. Please ensure the fare is a valid number.");
            }
        }

        private void checkButton_Click(object sender, EventArgs e)
        {

            try

            {
                // Declare a variable and initialize it with
                // the passenger's input.
                if (int.TryParse(airplaneFlightPassengerSeatCountTextBox.Text, out int combinedPax))
                {
                    // Check the combinedPax's range.
                    if (combinedPax >= 1 && combinedPax <= 50)
                    {
                        MessageBox.Show("The combined number of Pax are acceptable.");
                        outputCopiedPaxIntegerLabel1.Text = combinedPax.ToString();
                        outputCopiedPaxIntegerLabel2.Text = combinedPax.ToString();
                        outputCopiedPaxIntegerLabel3.Text = combinedPax.ToString();
                        outputCopiedPaxIntegerLabel5.Text = combinedPax.ToString();
                    }
                    else
                    {
                        MessageBox.Show("The combined number of Pax are unacceptable and you need to contact our tourism information center if the booking requires a full airplane.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Display an error message.
                MessageBox.Show(ex.Message);
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            outputLabelAirlineName.Text = "";
            outputCopiedPaxIntegerLabel1.Text = "";
            outputBudgetToFitLabel.Text = "";
            outputLabelFareOnThisFlight.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            outputhotelCharacteristicsLabel.Text = "";
            outputCopiedPaxIntegerLabel2.Text = "";
            outputLabelFareOnThisRoom.Text = "";
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {

            try
            {
                // Declare variables to hold number of pax and their sum.
                decimal airlineFares, lodgingFares, combinedSiteSeeingFares, combinedPrice;

                // Get the total number of PAX on board.
                if (decimal.TryParse(outputLabelFareOnThisFlight.Text, out airlineFares))
                {
                    // Get the total number of guests in pax
                    if (decimal.TryParse(outputLabelFareOnThisRoom.Text, out lodgingFares))
                    {
                        //Get the total number of visitors in pax
                        if (decimal.TryParse(outputLabelFareOnThisTouristSite.Text, out combinedSiteSeeingFares))
                        {
                            // Get the sum of the .
                            combinedPrice = Sum(airlineFares, lodgingFares, combinedSiteSeeingFares);

                            // Display the combined Pax.
                            combinedPricingLabel2.Text = combinedPrice.ToString();
                        }
                        else
                        {
                            // Display an error message.
                            MessageBox.Show("Select a an airline, room and sightseeing fares for your combined boarding pass and ticket fare");
                        }
                    }
                    else
                    {
                        // Display an error message.
                        MessageBox.Show("Enter an integer for your number of Pax.");
                    }
                }

                int passengerPax;
                int guestPax;
                int visitorPax;
                int combinedPax;
                passengerPax = int.Parse(numberOfPaxLabel.Text);
                guestPax = int.Parse(numberOfPaxLabel2.Text);
                visitorPax = int.Parse(numberOfPaxLabel3.Text);
                if (passengerPax >= 1)
                {
                    combinedPax = passengerPax;
                    passengerPax = guestPax;
                    guestPax = visitorPax;
                }
                //outputCombinedPaxLabel2.Text = combinedPax.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void getRestaurantPriceButton_Click(object sender, EventArgs e)
        {
            //if (decimal.TryParse(outputLabelFareOnThisFlight.Text, out airplaneFares))
            //{ 
            string combinedRestaurants;

            if (decimal.TryParse(outputLabelFareOnThisRoom.Text, out decimal lodgingFares))
            {
                if (decimal.TryParse(outputLabelFareOnThisTouristSite.Text, out decimal combinedSiteSeeingFares))
                {
                    if (decimal.TryParse(budgetValueTextBox.Text, out decimal budgetValue))
                    {

                        if (lodgingFares >= combinedSiteSeeingFares || combinedSiteSeeingFares >= budgetValue)
                        {
                            if (budgetValue <= combinedSiteSeeingFares || budgetValue >= lodgingFares)
                                // Continue to process the input.
                                // To hold the name of a restaurant or group of restaurants that fit to tourism  categories, country and fare fit to budget

                                if (restaurantsPricesListBox.SelectedIndex != -1)
                                {
                                    if (restaurantsPricesListBox.SelectedIndex == 1)
                                    {
                                        // Get the selected item.
                                        combinedRestaurants = restaurantsPricesListBox.SelectedItem.ToString();


                                        outputLabelPriceForThisRestaurants.Text = combinedRestaurants;


                                        // Determine the sightseeing fare
                                        switch (combinedRestaurants)
                                        {
                                            case "PF Chang's":
                                                outputLabelPriceForThisRestaurants.Text = "200";
                                                break;
                                            case "Ben's Chilli Bowl: Washignton DC location":
                                                outputLabelPriceForThisRestaurants.Text = "150";
                                                break;
                                            default:
                                                MessageBox.Show("Restaurant Chain must be either in listing or pricing process");
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Please select a restaurant from the list");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Insufficient fit to budget of tour");
                                }
                        }
                        else
                        {
                            MessageBox.Show("The budget selection must either increase or select other items on the previous tour sections.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid budget value. Please ensure the budget is a valid number.");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid sightseeing fare. Please ensure the fare is a valid number.");
                }
            }
            else
            {
                MessageBox.Show("Invalid lodging fare. Please ensure the fare is a valid number.");
            }
        }

        private void combinedReferenceForPax_Click(object sender, EventArgs e)
        {
            try
            {

                // Declare an int variable.
                int combinedBoardingPassAndTicket;
                // Create a Random object.
                var rand = new Random();
                // Get a random integer and assign it to number.
                combinedBoardingPassAndTicket = rand.Next();
                outputCombinedReference.Text = combinedBoardingPassAndTicket.ToString();

                // Declare a StreamWriter variable.
                StreamWriter outputFile;

                // Create a file and get a StreamWriter object.
                outputFile = File.AppendText("TicketReferecnes.txt");

                // Write the friend's name to the file.
                outputFile.WriteLine(outputCombinedReference.Text);


                // Close the file.
                outputFile.Close();

                // Let the user know the name was written.
                MessageBox.Show("The random reference number was written.");
            }
            catch (Exception ex)
            {
                // Display an error message.
                MessageBox.Show(ex.Message);
            }
        }

        private void refreshPriceDataType_Click(object sender, EventArgs e)
        {
            // Declare some local int variables.
            decimal airlineFares, lodgingFares, combinedSiteSeeingFares, combinedRestaurants;

            decimal.TryParse(outputLabelFareOnThisFlight.Text, out airlineFares);
            decimal.TryParse(outputLabelFareOnThisRoom.Text, out lodgingFares);
            decimal.TryParse(outputLabelFareOnThisTouristSite.Text, out combinedSiteSeeingFares);
            decimal.TryParse(outputLabelPriceForThisRestaurants.Text, out combinedRestaurants);

            // Display the values in those variables.
            outputResetValuesListBox.Items.Clear();
            outputResetValuesListBox.Items.Add("airlineFares are set to " + airlineFares);
            outputResetValuesListBox.Items.Add("lodgingFares are set to " + lodgingFares);
            outputResetValuesListBox.Items.Add("combinedSiteSeeingFares are set to " + combinedSiteSeeingFares);
            outputResetValuesListBox.Items.Add("combinedRestaurants are set to " + combinedRestaurants);

            // Pass each variable to SetToZero.
            SetToZero(ref airlineFares);
            SetToZero(ref lodgingFares);
            SetToZero(ref combinedSiteSeeingFares);
            SetToZero(ref combinedRestaurants);


            // Display the values in those variables again.
            outputResetValuesListBox.Items.Add("--------------------");
            outputResetValuesListBox.Items.Add("airlineFares are set to " + airlineFares);
            outputResetValuesListBox.Items.Add("lodgingFares are set to " + lodgingFares);
            outputResetValuesListBox.Items.Add("combinedSiteSeeingFares are set to " + combinedSiteSeeingFares);
            outputResetValuesListBox.Items.Add("combinedRestaurants are set to " + combinedRestaurants);
        }

        private void airlineSelectionColorControl_CheckedChanged(object sender, EventArgs e)
        {
            if (airlineSelectionColorControl.Checked)
            {
                automatedTourOperatourFutureGoal.BackColor = Color.Blue;
            }
        }

        private void insertBudget_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    decimal budgetValue;
                    budgetValue = decimal.Parse(budgetValueTextBox.Text);
                    if (budgetValue != 300 && budgetValue < 300)
                        MessageBox.Show("Increase Budget");
                    outputBudgetToFitLabel.Text = budgetValue.ToString();
                    outputBudgetToFitLabel2.Text = budgetValue.ToString();
                    outputBudgetToFitLabel3.Text = budgetValue.ToString();
                    outputBudgetToFitLabel4.Text = budgetValue.ToString();

                }

                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }
        private void clearButton3RD_Click(object sender, EventArgs e)
        {
            outputLabelAirlineName.Text = "";
            outputCopiedPaxIntegerLabel1.Text = "";
            outputLabelFareOnThisFlight.Text = "";
            outputBudgetToFitLabel.Text = "";
            outputhotelCharacteristicsLabel.Text = "";
            outputCopiedPaxIntegerLabel2.Text = "";
            outputLabelFareOnThisRoom.Text = "";
            outputBudgetToFitLabel2.Text = "";
            outputifOnlyOneTourOptionListed.Text = "";
            outputBookedSightSeeingGatesLabel.Text = "";
            outputCopiedPaxIntegerLabel3.Text = "";
            outputLabelFareOnThisTouristSite.Text = "";
            outputBudgetToFitLabel3.Text = "";
            outputBookedRestaurantsSeatsLabel.Text = "";
            outputBookedRestaurantSeatsLabel.Text = "";
            outputCopiedPaxIntegerLabel5.Text = "";
            outputLabelPriceForThisRestaurants.Text = "";
            outputBudgetToFitLabel4.Text = "";
            outputCombinedReference.Text = "";
            combinedPricingLabel2.Text = "";
            outputGrossPayment.Text = "";
            outputCombinedPaxLabel2.Text = "";
            outputResetValuesListBox.Text = "";
        }

        private void displayValueOfPAXOnThisPage_Click_1(object sender, EventArgs e)
        {
            if (int.TryParse(airplaneFlightPassengerSeatCountTextBox.Text, out int mainCountPax) &&
                           int.TryParse(outputCopiedPaxIntegerLabel1.Text, out int countAirlinePax) &&
                           int.TryParse(outputCopiedPaxIntegerLabel2.Text, out int countRoomPax) &&
                           int.TryParse(outputCopiedPaxIntegerLabel3.Text, out int countSiteSeeingTicketsAndPax) &&
                           int.TryParse(outputCopiedPaxIntegerLabel5.Text, out int countRestaurants))
            {
                if (mainCountPax == countAirlinePax && mainCountPax == countRoomPax &&
                    mainCountPax == countSiteSeeingTicketsAndPax && mainCountPax == countRestaurants)
                {
                    int combinedPax = mainCountPax;
                    outputCopiedPaxIntegerLabel1.Text = combinedPax.ToString();
                    outputCombinedPaxLabel2.Text = combinedPax.ToString();
                    outputCopiedPaxIntegerLabel3.Text = combinedPax.ToString();
                    outputCopiedPaxIntegerLabel5.Text = combinedPax.ToString();

                    // Constant for the maximum number
                    const int MAX_PAX = 4;

                    // Loop counter
                    int number;

                    // Display the list of numbers and their squares.
                    for (number = 3; number <= MAX_PAX; number++)
                    {
                        forLoopListBox.Items.Add("The credit points of " + number + " PAX is " + (3 * 100) + "points in the mileage system");
                    }
                }

                else
                {
                    MessageBox.Show("Passenger counts do not match across all fields.");
                }
            }
            else
            {
                MessageBox.Show("Invalid input. Please ensure all fields contain valid numbers.");
            }
        }

        private void displayAirlineFaresRepeatedly_Click(object sender, EventArgs e)
        {
            if (airLineFaresListBox.SelectedIndex != -1)
            {
                const decimal SELECTED_PRICE = 1m;
                string airlineFare = airLineFaresListBox.SelectedItem.ToString();

                for (decimal fare = 0; fare < SELECTED_PRICE; fare++)
                {
                    forLoopListBox.Items.Add("The airline fare on this plane is " + fare + " and " + " the weather is good");
                }
            }
        }

        private void lodgingSelectionColorControl_CheckedChanged(object sender, EventArgs e)
        {
            if (lodgingSelectionColorControl.Checked)
            {
                automatedTourOperatourFutureGoal.BackColor = Color.Green;
            }
        }

        private void sigthSeeingSelectionColorControl_CheckedChanged(object sender, EventArgs e)
        {
            if (sigthSeeingSelectionColorControl.Checked)
            {
                automatedTourOperatourFutureGoal.BackColor = Color.Pink;
            }
        }

        private void restaurantsSelectionColorControl_CheckedChanged(object sender, EventArgs e)
        {
            if (restaurantsSelectionColorControl.Checked)
            {
                automatedTourOperatourFutureGoal.BackColor = Color.Lime;
            }
        }

        private void comparePriceAndBudgetMatch_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    // Declare a string variable and initialize it with
                    // the tourist's input.
                    // Did the tourist enter the correct budgetWord?
                    if (decimal.TryParse(outputLabelFareOnThisFlight.Text, out decimal airlineFares))
                    {
                        if (decimal.TryParse(budgetValueTextBox.Text, out decimal budgetWord))
                        {
                            if (airlineFares > budgetWord)
                            {
                                MessageBox.Show("That is incorrect secret budget word.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Okay, that still fit with your calculated secret budget word.");

                        }
                    }
                    else
                    {
                        MessageBox.Show("Okay");
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void refreshPriceDataType_Click_1(object sender, EventArgs e)
        {
            // Declare some local int variables.
            decimal airlineFares, lodgingFares, combinedSiteSeeingFares, combinedRestaurants;

            decimal.TryParse(outputLabelFareOnThisFlight.Text, out airlineFares);
            decimal.TryParse(outputLabelFareOnThisRoom.Text, out lodgingFares);
            decimal.TryParse(outputLabelFareOnThisTouristSite.Text, out combinedSiteSeeingFares);
            decimal.TryParse(outputLabelPriceForThisRestaurants.Text, out combinedRestaurants);

            // Display the values in those variables.
            outputResetValuesListBox.Items.Clear();
            outputResetValuesListBox.Items.Add("airlineFares are set to " + airlineFares);
            outputResetValuesListBox.Items.Add("lodgingFares are set to " + lodgingFares);
            outputResetValuesListBox.Items.Add("combinedSiteSeeingFares are set to " + combinedSiteSeeingFares);
            outputResetValuesListBox.Items.Add("combinedRestaurants are set to " + combinedRestaurants);

            // Pass each variable to SetToZero.
            SetToZero(ref airlineFares);
            SetToZero(ref lodgingFares);
            SetToZero(ref combinedSiteSeeingFares);
            SetToZero(ref combinedRestaurants);


            // Display the values in those variables again.
            outputResetValuesListBox.Items.Add("--------------------");
            outputResetValuesListBox.Items.Add("airlineFares are set to " + airlineFares);
            outputResetValuesListBox.Items.Add("lodgingFares are set to " + lodgingFares);
            outputResetValuesListBox.Items.Add("combinedSiteSeeingFares are set to " + combinedSiteSeeingFares);
            outputResetValuesListBox.Items.Add("combinedRestaurants are set to " + combinedRestaurants);
        }

        private void calculate_Click(object sender, EventArgs e)
        {


        }

        private void getPayment_Click(object sender, EventArgs e)
        {
            try
            {
                // Declare variables to hold number of pax and their sum.
                int combinedPax;
                decimal combinedPrice;
                decimal grossPayment;

                // Get the pax of the tour sections combined
                if (int.TryParse(outputCombinedPaxLabel2.Text, out combinedPax))
                {
                    // Get the prices of the tour sections combined
                    if (decimal.TryParse(combinedPricingLabel2.Text, out combinedPrice))
                    {

                        // Get the sum of the tour.
                        grossPayment = Multiplication(combinedPrice, combinedPax);

                        // Display the grossPayment
                        outputGrossPayment.Text = grossPayment.ToString();

                    }
                    else
                    {
                        // Display an error message.
                        MessageBox.Show("Select a an airline, room and sightseeing fares for your combined boarding pass and ticket fare");
                    }
                }
                else
                {
                    // Display an error message.
                    MessageBox.Show(" adjust the tourist information in one of the fares an integer.");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void touristIdentification_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            const int SIZE = 5;
            var touristIdentityNumbers = new int[SIZE];
            var touristIdentityWords = new string[SIZE];
            // Array to hold numbers with letters/words 
            //Create a Random object. 
            var rand = new Random();
            // Fill the array with random numbers, in the range // of 0 through 99.   (add back if you want 
            for (int index = 0; index < touristIdentityNumbers.Length; index++)
            {
                touristIdentityNumbers[index] = rand.Next(100, 300);
                // Add a letter or word to each number
                touristIdentityWords[index] = "Unified Tourist ID Number";
            }

            // Assuming you have labels named outputTouristIdentityLabel1, outputTouristIdentityLabel2, etc., 
            // for words and outputTouristNumberLabel1, //outputTouristNumberLabel2, etc., for numbers.

            // Display the array elements in the Label controls.
            outputTouristIdentityLabel.Text = touristIdentityWords[0];
            outputTouristIdentityLabel1.Text = touristIdentityNumbers[1].ToString();
            outputTouristIdentityLabel2.Text = touristIdentityNumbers[2].ToString();
            outputTouristIdentityLabel3.Text = touristIdentityNumbers[3].ToString();
            outputTouristIdentityLabel4.Text = touristIdentityNumbers[4].ToString();
        }

        private void passengerButton_Click(object sender, EventArgs e)
        {
            try
            {

                // Create an array to hold three strings.
                const int SIZE = 10;
                string[] names = new string[SIZE];

                // Get the names.
                names[0] = passengerFirstName.Text;
                names[1] = passengerNameTextBox1.Text;
                names[2] = passengerNameTextBox4.Text;
                names[3] = passengerNameTextBox5.Text;
                names[4] = passengerNameTextBox6.Text;

                // Display the names.
                // MessageBox.Show(names[0]);
                //MessageBox.Show(names[1]);
                //MessageBox.Show(names[2]);
                //MessageBox.Show(names[3]);
                //MessageBox.Show(names[4]);

                //write the names on file
                // Declare a StreamWriter variable.
                StreamWriter outputFile;

                // Create a file and get a StreamWriter object.
                outputFile = File.AppendText("PassengerNamesOnOneStopTouristIdentityApplication.txt");


                // Write the friend's name to the file.
                outputFile.WriteLine(passengerFirstName.Text + passengerNameTextBox1.Text + passengerNameTextBox4.Text + passengerNameTextBox5.Text + passengerNameTextBox6.Text);

                for (int index = 0; index < names.Length; index++)
                {
                    outputFile.WriteLine(names[index]);
                }

                // Close the file.
                outputFile.Close();

                // Let the user know the name was written.
                MessageBox.Show("The passenger name was written.");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        //
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}




         
    
            
    




        
    




    

































