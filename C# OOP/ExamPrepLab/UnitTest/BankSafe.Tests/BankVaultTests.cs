using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private Item item;
        private BankVault bankVault;
        [SetUp]
        public void Setup()
        {
            this.item = new Item("Gosho", "pochivka");
            this.bankVault = new BankVault();
        }

        [Test]
        public void AddItem_ThrowsException_WhenCellWrong()
        {
            Assert.Throws<ArgumentException>(() => bankVault.AddItem("nqma takava", item));
        }
        [Test]
        public void AddItem_ThrowsException_WhenCellAlreadyTake()
        {
            this.bankVault.AddItem("A1", item);
            Assert.Throws<ArgumentException>(() => bankVault.AddItem("A1", new Item("noviq","2314")));
        }

        [Test]
        public void AddItem_ThrowsException_WhenItemAlreadyTaken()
        {
            this.bankVault.AddItem("A1", item);
            Assert.Throws<InvalidOperationException>(() => bankVault.AddItem("A2", item));
        }

        [Test]
        public void AddItem_Correctly()
        {
            this.bankVault.AddItem("A1", item);
            Assert.IsTrue(bankVault.VaultCells["A1"] == item);
        }

        [Test]
        public void AddItem_CorrectlyAndReturnsString()
        {
            string result = this.bankVault.AddItem("A1", item);
            Assert.IsTrue(result == $"Item:{item.ItemId} saved successfully!");
        }

        [Test]
        public void Remove_ThrowsException_WhenCellDoesntExist()
        {
            Assert.Throws<ArgumentException>(() => this.bankVault.RemoveItem("nqma takava",item));
        }
        [Test]
        public void Remove_ThrowsException_WhenItemDoesntExist()
        {
            Assert.Throws<ArgumentException>(() => this.bankVault.RemoveItem("A1", new Item("nqmcho","Nqmchov")));
        }

        [Test]
        public void Remove_Correctly()
        {
            this.bankVault.AddItem("A1", item);
            string result = bankVault.RemoveItem("A1", item);
            Assert.That(result == $"Remove item:{item.ItemId} successfully!");
            Assert.That(bankVault.VaultCells["A1"] == null);
        }
    }
}