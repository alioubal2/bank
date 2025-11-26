# Bank – Application de gestion bancaire (C# / .NET + PostgreSQL + Interface Graphique)

## 👤 Auteurs
- Projet réalisé par **Aliou Baldé** & **Baillo**
- Travail collaboratif à distance
- Encadrement : M. Damang Lanciné Saran

---

## 🎯 Objectif du projet
Développer une application bancaire avec **interface graphique**, permettant la gestion :

- des agences
- des clients
- des comptes bancaires
- des opérations financières
- d’un historique complet des transactions
- d’une base de données PostgreSQL pour la persistance

---

## 🧩 Fonctionnalités

### 🔹 Agences
- Création d’une agence
- Modification / suppression
- Liste & recherche
- Association de clients à une agence

### 🔹 Clients
- Ajout / modification / suppression
- Consultation
- Chaque client possède **un seul compte**

### 🔹 Types de comptes
- **Compte Épargne**
  - Taux d’intérêt : 5 %
  - Méthode `CalculInteret()`
- **Compte Courant**
  - Découvert autorisé
- **Compte Payant**
  - Frais fixes : 15 GNF par opération (retrait / dépôt)

### 🔹 Opérations bancaires
- Dépôt
- Retrait
- Virement entre comptes
- Consultation du solde
- Mise à jour des intérêts
- Historique complet des opérations

---

## 🗄️ Base de données PostgreSQL
Utilisation de **Entity Framework Core + PostgreSQL**.

### 📦 Tables :
- Agences
- Clients
- Comptes
- Operations

### 🔌 Configuration
Modifier la chaîne de connexion dans :

/Data/AppDbContext.cs

---

## 🏗️ Architecture du projet (GUI + PostgreSQL)

Bank/
│
├── Data/
│ ├── Repositories
| ├── Migrations
│ └── BankDbContext.cs
│
├── Models/
│ ├── Agence.cs
│ ├── Client.cs
│ ├── Compte.cs
│ ├── CompteEpargne.cs
│ ├── CompteCourant.cs
│ ├── ComptePayant.cs
│ └── Operation.cs
│
├── Services/
│ ├── AgenceService.cs
│ ├── ClientService.cs
│ ├── CompteService.cs
| ├── HistoriqueService.cs
│ └── OperationService.cs
│
├── GUI\Forms
│ ├── AgenceForm.cs
│ ├── MainForm.cs
│ ├── ClientForm.cs
│ ├── CompteForm.cs
│ └── OperationForm.cs
│
└── Bank.csproj


---

## 🎨 Interface Graphique
### ✔ Fenêtre principale
- Navigation entre les modules : Agences, Clients, Comptes, Opérations

### ✔ Fenêtres spécifiques
- Formulaires d’ajout
- DataGrid pour affichage
- Recherche / filtres
- Historique des opérations

---

## 🚀 Exécution du projet

### ⚙️ Restaurer les dépendances

dotnet restore

### 🗄️ Appliquer les migrations

dotnet ef database update

### ▶ Lancer l’application

dotnet run

---

## 📝 Diagramme UML
Stocké dans :

Docs/UML.png

---

## 📌 Version du Projet
**v2.0.0 — Interface Graphique + PostgreSQL + Architecture Optimisée**

---

## 💡 Notes
- Architecture modulaire (Models → Repositories → Services → UI)
- Projet évolutif pour ajout d’API ou tableau de bord statistique

