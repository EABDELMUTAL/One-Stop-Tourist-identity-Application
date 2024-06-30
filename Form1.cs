using System;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq.Expressions;
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
        private decimal Sum(decimal num1, decimal num2, decimal num3, decimal num4)
        {
            return num1 + num2 + num3 + num4;
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
            try

            {
                // To hold the name of an airlines and its fare temporary
                string airlineFares;

                //check selected airlineFares in listbox
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

            catch
            {
                MessageBox.Show("There is an exception to  handle");
            }
        }


        private void getPriceFromAnnouncedListPrice_Click(object sender, EventArgs e)
        {
            try
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
            catch
            {
                MessageBox.Show("There is an exception to handle caused by the Parse");
            }

        }


        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void getPriceFromAnnouncedSiteListPriceButton_Click(object sender, EventArgs e)
        {
            try
            {

                if (decimal.TryParse(outputLabelFareOnThisRoom.Text, out decimal lodgingFares))
                {
                    if (decimal.TryParse(budgetValueTextBox.Text, out decimal budgetValue))
                    {
                        if (lodgingFares >= 0 && lodgingFares <= budgetValue)
                        {
                            // Continue to process the input.
                            // To hold the name of an eTour fit to Tourism Category, country and fare fit to budget
                            string combinedSiteSeeingFares;


                            if (siteSeeingFaresListBox.SelectedIndex != -1)
                            {
                                // if (siteSeeingFaresListBox.SelectedIndex == 1)
                                // Get the selected item.
                                combinedSiteSeeingFares = siteSeeingFaresListBox.SelectedItem.ToString();
                                ///outputBookedSightSeeingGatesLabel.Text = eTourTourismAttractions;

                                // Determine the sightseeing fare
                                switch (combinedSiteSeeingFares)
                                {
                                    case "eTours Tides Tourism Attraction, Mont Saint, Michel: France: Airport Paris-Charles De Gaulle(CDG)":
                                        outputLabelFareOnThisTouristSite.Text = "400";
                                        break;
                                    case "eTours Tides Tourism Attraction, Mont Saint, Michel Bay: Canada: Airport Montreal Mirabel Intl Apt(YMX)":
                                        outputLabelFareOnThisTouristSite.Text = "200";
                                        break;
                                    case "eTour Onboard Water Sports via Ships Attraction, Seabourn Odyssey: Point of Sail Western Mediterranean Cruise":
                                        outputLabelFareOnThisTouristSite.Text = "300";
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
                                MessageBox.Show(" Please select a restaurant fare.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("The budget selection must either increase or select other items on the previous tourism sector. Insufficient fit to budget tour");
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

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                    if (combinedPax >= 1 && combinedPax <= 2)
                    {
                        MessageBox.Show("The combined number of Pax are acceptable.");
                        outputCopiedPaxIntegerLabel1.Text = combinedPax.ToString();
                        outputCopiedPaxIntegerLabel2.Text = combinedPax.ToString();
                        outputCopiedPaxIntegerLabel3.Text = combinedPax.ToString();
                        outputCopiedPaxIntegerLabel5.Text = combinedPax.ToString();
                    }
                    else
                    {
                        MessageBox.Show("The combined number of Pax are unacceptable and you need to contact our tourism information center if the booking requires a group or a full airplane.");
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
                // Declare variables to hold price fares of tourism components and their sum.
                decimal airlineFares;
                decimal lodgingFares;
                decimal combinedSiteSeeingFares;
                decimal combinedRestaurantFares;
                decimal combinedPrice;

                // Get the total number of PAX on board.
                if (decimal.TryParse(outputLabelFareOnThisFlight.Text, out airlineFares))
                {
                    // Get the total number of guests in pax
                    if (decimal.TryParse(outputLabelFareOnThisRoom.Text, out lodgingFares))
                    {
                        //Get the total number of visitors in pax
                        if (decimal.TryParse(outputLabelFareOnThisTouristSite.Text, out combinedSiteSeeingFares))
                        {

                            //Get the total number of visitors in pax
                            if (decimal.TryParse(outputLabelPriceForThisRestaurants.Text, out combinedRestaurantFares))
                            {
                                // Get the sum of the .
                                combinedPrice = Sum(airlineFares, lodgingFares, combinedSiteSeeingFares, combinedRestaurantFares);

                                // Display the combined Pax.
                                combinedPricingLabel2.Text = combinedPrice.ToString();
                            }
                            else
                            {
                                // Display an error message.
                                MessageBox.Show("Select an airline, room, automated Gateway tours Sightseeing Attractions and restaurants fares for your combined boarding pass and ticket fare");
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void getRestaurantPriceButton_Click(object sender, EventArgs e)
        {
            try
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

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                        MessageBox.Show("Increase Budget and compare it with every section of the ticket before you pack and travel");
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
            outputCopiedPaxIntegerLabel3.Text = "";
            outputLabelFareOnThisTouristSite.Text = "";
            outputBudgetToFitLabel3.Text = "";
            outputBookedRestaurantsSeatsLabel.Text = "";
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
            try
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
                        const int MAX_PAX = 3;

                        // Loop counter
                        int number;

                        // Display the list of numbers and their squares.
                        for (number = 2; number <= MAX_PAX; number++)
                        {
                            forLoopListBox.Items.Add("The credit points of " + number + " PAX is " + (2 * 100) + "points in the mileage system");
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void displayAirlineFaresRepeatedly_Click(object sender, EventArgs e)
        {
      
            if (airLineFaresListBox.SelectedIndex != -1)
            {
                const decimal SELECTED_PRICEPERPOINT = 1m;
                string airlineFare = airLineFaresListBox.SelectedItem.ToString();

                for (decimal fare = 0; fare < SELECTED_PRICEPERPOINT; fare++)
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
                    if (int.TryParse(outputLabelFareOnThisFlight.Text, out int airlineFares))
                    {
                        if (int.TryParse(budgetValueTextBox.Text, out int budgetValue))
                        {
                            if (airlineFares == budgetValue || airlineFares > budgetValue)
                            {
                                MessageBox.Show("Budget value does not fit.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Okay, that does not fit with your calculated Budget value.");

                        }
                    }
                    else
                    {
                        MessageBox.Show("Now, Okay!");
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
        
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void goButtonWhileLoop_Click(object sender, EventArgs e, object totalAirlinrFare)
        {

        }

        private void goButtonWhileLoop2_Click(object sender, EventArgs e)
        {
            try
            {
                // Constant for the monthly sales tax rate
                // const decimal NATIONAL_IDENTITYTHEFT = 0.001m;
                //const decimal WASTE_MANAGEMENT = 0.001m;
                //const decimal SUSTAINABILITY_ENVIRONEMENT = 0.001m;
                const int MAX_VALUE = 2;
                const int START_PAX = 1;
                const int INTERVALS = 1;


                // Local variables
                int lodgingFares;              // The price from the price list
                int pax;                          // The number of pax
                int count = 1;                // Loop counter, initialized with 1


                // Get the fit price to the budget.
                if (int.TryParse(outputLabelFareOnThisRoom.Text, out lodgingFares))
                {
                    // Get the number of pax.
                    if (int.TryParse(outputCopiedPaxIntegerLabel2.Text, out pax))
                    {
                        // The following loop calculates the price of this portion of the mandatory   combined boarding pass and ticket
                        for (pax = START_PAX; pax <= MAX_VALUE; pax += 1)
                        {
                            // calculate the flight price to compare with the budget down
                            //portion of the combined fare ticket
                            lodgingFares = lodgingFares * pax;
                            // Add one to the loop counter.
                            count = count + 1;


                            // Display the new flightPrice.
                            // outputLabelFareOnThisRoom.Text = lodgingFares.ToString("n");
                            lodgingFaresListBox.Items.Add(pax.ToString("n") + " pax has the rate like that " + lodgingFares.ToString("n1"));
                        }
                    }
                    else
                    {
                        // Invalid number of pax was entered.
                        MessageBox.Show("Invalid value for pax.");
                    }
                    }
                    else
                    {
                        // Invalid flightPrice was entered.
                        MessageBox.Show("Invalid value for lodgingFares.");
                    }
                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          }
        
        private void goButtonWhileLoop3_Click(object sender, EventArgs e)
        {
            try
            {
                // Constant for the monthly sales tax rate
                const int MAX_VALUE = 2;
                const int START_PASSENGERNUMBER = 1;
                const int INTERVALS = 1;

                // Local variables
                int combinedSiteSeeingFares;
                int pax;
                // int combinedSiteSeeingFares;              // The price from the price list
                //int pax;                          // The number of pax
                int count = 1;                // Loop counter, initialized with 1

                // Get the fit price to the budget.
                if (int.TryParse(outputLabelFareOnThisTouristSite.Text, out combinedSiteSeeingFares))
                {
                    // Get the number of pax.
                    if (int.TryParse(outputCopiedPaxIntegerLabel3.Text, out pax))
                    {
                        // The following loop calculates the price of this portion of the mandatory   combined boarding pass and ticket
                        for (pax = START_PASSENGERNUMBER; pax <= MAX_VALUE; pax += 1)
                        {
                            // calculate the flight price to compare with the budget down
                            //portion of the combined fare ticket
                            combinedSiteSeeingFares = combinedSiteSeeingFares * pax;
                            // Add one to the loop counter.
                            count = count + 1;
                            // Display the new flightPrice.
                            //outputLabelFareOnThisTouristSite.Text = combinedSiteSeeingFares.ToString("n");
                            eTourTourismAttractionsListBox.Items.Add(pax.ToString() + " pax has the rate like that " + combinedSiteSeeingFares.ToString("n1"));
                        }
                    }
                    else
                    {
                        // Invalid number of pax was entered.
                        MessageBox.Show("Invalid value for pax.");
                    }
                }
                else
                {
                    // Invalid flightPrice was entered.
                    MessageBox.Show("Invalid value for combinedSiteSeeingFares.");
                }
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message);
            }
        }

        private void goButtonWhileLoop4_Click(object sender, EventArgs e)
        {
            try
            {
                // Constant for the monthly sales tax rate
                const int MAX_VALUE = 2;
                const int START_PAX = 1;
                const int INTERVALS = 1;

                // Local variables
                int combinedRestaurants;              // The price from the price list
                int pax;                          // The number of pax
                int count = 1;                // Loop counter, initialized with 1


                // Get the fit price to the budget.
                if (int.TryParse(outputLabelPriceForThisRestaurants.Text, out combinedRestaurants))
                {
                    // Get the number of pax.
                    if (int.TryParse(outputCopiedPaxIntegerLabel5.Text, out pax))
                    {
                        // The following loop calculates the price of this portion of the mandatory   combined boarding pass and ticket
                        for (pax = START_PAX; pax <= MAX_VALUE; pax += 1)
                        {
                            // calculate the flight price to compare with the budget down
                            //portion of the combined fare ticket
                            combinedRestaurants = combinedRestaurants * pax;

                            // Add one to the loop counter.
                            count = count + 1;


                            // Display the new flightPrice.
                            //outputLabelPriceForThisRestaurants.Text = combinedRestaurants.ToString("n");
                            automatedRestaurnatsBookingListBox.Items.Add(pax.ToString("n") + " pax has the rate like that " + combinedRestaurants.ToString("n1"));
                        }
                    }
                    else
                    {
                        // Invalid number of pax was entered.
                        MessageBox.Show("Invalid value for pax.");
                    }
                }
                else
                {
                    // Invalid flightPrice was entered.
                    MessageBox.Show("Invalid value for combinedRestaurants.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comparePriceAndBudgetMatch2_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    int airlineFares;
                    // Declare a string variable and initialize it with
                    // the tourist's input.
                    // Did the tourist enter the correct budgetValue?
                    if (decimal.TryParse(outputLabelFareOnThisRoom.Text, out decimal lodgingFares))
                    { 
                        if (int.TryParse(outputLabelFareOnThisFlight.Text, out airlineFares))
                        { 
                            //{
                              //  if (decimal.TryParse(budgetValueTextBox.Text, out decimal budgetValue))
                       // {
                            if (lodgingFares > airlineFares)
                            {
                                MessageBox.Show("That room fare is not a budget fit value.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Okay, that still fit with your calculated secret budget value.");

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

        private void goButtonWhileLoop_Click(object sender, EventArgs e)
        {

            try
            {

                // Constant for the monthly sales tax rate
                // const int PERCENTAGE_NATIONALIDENTITYTHEFT = 10;
                // const int PERCENTAGE_WASTEMANAGEMENT = 10;
                //  const int PERCENTAGE_SUSTAINABILITYENVIRONEMENT = 10;
                const int MAX_VALUE = 2;
                const int START_PAX = 1;
                const int INTERVALS = 1;

                // Local variables
                int pax;                        // The number of pax
                int airlineFares;              // The price from the price list
                int count = 1;                // Loop counter, initialized with 1


                // Get the fit price to the budget.
                if (int.TryParse(outputLabelFareOnThisFlight.Text, out airlineFares))
                {
                    // Get the number of pax.
                    if (int.TryParse(outputCopiedPaxIntegerLabel1.Text, out pax))

                    {
                        // airlineFares = (airlineFares * PERCENTAGE_NATIONALIDENTITYTHEFT) + (airlineFares * PERCENTAGE_WASTEMANAGEMENT) * (airlineFares * PERCENTAGE_SUSTAINABILITYENVIRONEMENT);
                        // outputLabelFareOnThisFlight.Text = airlineFares.ToString("n");
                    }
                    {
                        // The following loop calculates the price of this portion of the mandatory combined boarding pass and ticket
                        for (pax = START_PAX; pax <= MAX_VALUE; pax += 1)
                        {
                            // calculate the flight price to compare with the budget down
                            //portion of the combined fare ticket
                            // Calculate the total flight price including additional charges
                            // We are using a loop to accumulate the fares
                            airlineFares = airlineFares * pax;
                            airlineFaresListBox2.Items.Add(pax.ToString("n") + " pax has the rate like that " + airlineFares.ToString("n1"));
                            // Add one to the loop counter.
                            count = count + 1;
                        }

                        // Display the new flightPrice.
                        // outputLabelFareOnThisFlight.Text = airLineFares.ToString("n");
                    }
                }
                else
                {
                    // Invalid number of pax was entered.
                    MessageBox.Show("Invalid value for pax and airlineFares.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mathTestingButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Initialize the airlineFares variable
                int airlineFares = 0;
                int logAirlineFare = 0;

                // Check if an item is selected in the list box
                if (airLineFaresListBox.SelectedIndex != -1)
                {
                    // Parse the selected item as an integer
                    airlineFares = int.Parse(airLineFaresListBox.SelectedItem.ToString());

                    // Calculate the natural logarithm of the airline fare
                    logAirlineFare = (int)Math.Log(airlineFares);

                    // Add the fare to the second list box
                    airlineFaresListBox2.Items.Add(logAirlineFare.ToString("n"));

                    // Display the result or use it as needed
                    MessageBox.Show($"The natural logarithm of the selected airline fare is {logAirlineFare}");
                }
                else
                {
                    // Handle the case where no item is selected
                    MessageBox.Show("No value selected. Please select a valid airline fare.");
                }
            }
            catch (Exception ex)
            {
                // Display any exception messages
                MessageBox.Show(ex.Message);
            }

        }

        private void comparePriceAndBudgetMatch4_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    int combinedRestaurantFares;
                    int combinedSiteSeeingFares;
                    int budgetValue;
                    // Declare a string variable and initialize it with
                    // the tourist's input.
                    // Did the tourist enter the correct budgetValue?
                    if (int.TryParse(outputLabelPriceForThisRestaurants.Text, out combinedRestaurantFares))
                    {
                        if (int.TryParse(outputLabelFareOnThisTouristSite.Text, out combinedSiteSeeingFares))
                        {

                            if (int.TryParse(budgetValueTextBox.Text, out budgetValue))
                            {
                                if (combinedRestaurantFares == budgetValue || combinedRestaurantFares > combinedSiteSeeingFares)
                                {
                                    MessageBox.Show("These combined restaurnats fare are not a budget fit value.");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Okay, that still fit with your calculated secret budget value.");

                            }
                        }
                        else
                        {
                            MessageBox.Show("Okay");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void comparePriceAndBudgetMatch3_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    int combinedSiteSeeingFares;
                    int lodgingFares;
                    int budgetValue;
                    // Declare a string variable and initialize it with
                    // the tourist's input.
                    // Did the tourist enter the correct budgetValue?
                    if (int.TryParse(outputLabelFareOnThisTouristSite.Text, out combinedSiteSeeingFares))
                    {
                        if (int.TryParse(outputLabelFareOnThisRoom.Text, out lodgingFares))
                        {

                            if (int.TryParse(budgetValueTextBox.Text, out budgetValue))
                            {
                                if (combinedSiteSeeingFares == budgetValue || combinedSiteSeeingFares > lodgingFares)
                                {
                                    MessageBox.Show("That combined siteseeing or tour operator fare is not a budget fit value.");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Okay, that still fit with your calculated secret budget value.");

                            }
                        }
                        else
                        {
                            MessageBox.Show("Okay");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
    































































