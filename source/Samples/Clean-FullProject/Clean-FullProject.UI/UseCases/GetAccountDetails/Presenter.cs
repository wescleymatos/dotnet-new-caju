﻿namespace Clean_FullProject.UI.UseCases.GetAccountDetails
{
    using Clean_FullProject.Application;
    using Clean_FullProject.Application.Outputs;
    using Clean_FullProject.UI.Model;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    public class Presenter : IOutputBoundary<AccountOutput>
    {
        public IActionResult ViewModel { get; private set; }
        public AccountOutput Output { get; private set; }

        public void Populate(AccountOutput output)
        {
            Output = output;

            if (output == null)
            {
                ViewModel = new NoContentResult();
                return;
            }

            List<TransactionModel> transactions = new List<TransactionModel>();

            foreach (var item in output.Transactions)
            {
                var transaction = new TransactionModel(
                    item.Amount,
                    item.Description,
                    item.TransactionDate);

                transactions.Add(transaction);
            }

            ViewModel = new ObjectResult(new AccountDetailsModel(
                output.AccountId,
                output.CurrentBalance,
                transactions));
        }
    }
}