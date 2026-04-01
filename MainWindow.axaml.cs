using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace GestionDeVignettesGUI;

public partial class MainWindow : Window
{
    string[] tabNumImmatriculation = new string[100];
    string[] tabTypeCarburant = new string[100];
    string[] tabEligibles = new string[100];
    int[] tabAnnee = new int[100];
    int[] tabNbCheveaux = new int[100];
    
    int nbVoiture;
    int nbVoitureEligible;
    public MainWindow()
    {
        InitializeComponent();
        nbVoiture = 0;
        nbVoitureEligible = 0;
    }

    private void Enregistrer_OnClick(object? sender, RoutedEventArgs e)
    {
        tabNumImmatriculation[nbVoiture] = textBoxNumImmatriculation.Text;
        tabAnnee[nbVoiture] = int.Parse(textBoxAnneeImmatriculation.Text);
        tabNbCheveaux[nbVoiture] = int.Parse(textBoxChevaux.Text);

        if (radioBtnDiesel.IsChecked == true)
        {
            tabTypeCarburant[nbVoiture] = "diesel";
        }
        else
        {
            tabTypeCarburant[nbVoiture] = "essence";
        }

        if ((DateTime.Now.Year - tabAnnee[nbVoiture]) >= 8)
        {
            listBoxVechicules.Items.Clear();
            tabEligibles[nbVoitureEligible] = tabNumImmatriculation[nbVoiture];
            
            for (int i = 0; i < nbVoitureEligible + 1; i++)
            {
                listBoxVechicules.Items.Add(tabEligibles[i]);
            }
            
            nbVoitureEligible++;
        }
        
        nbVoiture++;
    }

    private void Calculer_OnClick(object? sender, RoutedEventArgs e)
    {
        for (int i = 0; i < nbVoiture + 1; i++)
        {
            if (tabNumImmatriculation[i] == textBoxCalcImmatriculation.Text)
            {
                if (tabTypeCarburant[i] == "essence" && tabAnnee[i] >= 2013)
                {
                    textBlockVignette.Text = "1";
                    textBlockCouleur.Text = "Blanc";
                }
                else if (tabTypeCarburant[i] == "essence" && tabAnnee[i] < 2013)
                {
                    textBlockVignette.Text = "2";
                    textBlockCouleur.Text = "Vert";
                }

                if (tabTypeCarburant[i] == "diesel" && tabAnnee[i] >= 2013)
                {
                    textBlockVignette.Text = "3";
                    textBlockCouleur.Text = "Jaune";
                } 
                else if (tabTypeCarburant[i] == "diesel" && tabAnnee[i] < 2013)
                {
                    textBlockVignette.Text = "4";
                    textBlockCouleur.Text = "Orange";
                }
            }
        }
        
    }
}