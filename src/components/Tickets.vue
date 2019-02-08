<template>
    <div  id="tickets">

      <b-list-group class="justify-content-between align-items-center mt-4">
        <b-list-group-item class="show" button v-for="(ticket,index) in tickets" v-b-modal.modallg v-on:click="OpenModal(index)">
          <div class="show-date ">
            <div class="day"> {{ getDay(ticket.Date) }}</div>
            <div class="month">{{ getMonth(ticket.Date) }}</div>
          </div>
          <div class="show-info">
            <div class="show-name">
              {{ ticket.EventName }}
            </div>
          </div>
        </b-list-group-item>
      </b-list-group>

      <b-modal id="modallg" size="lg"  centered hide-footer >
        <img src="../assets/logo.png">
        <div> <h1>{{tickets[ticketId].EventName}} </h1></div>
        <div> <h2>{{tickets[ticketId].Artist}} </h2></div>
        <br/>
        <div> <h3>Date: {{tickets[ticketId].Date}} </h3></div>
        <div> <h3>Adresse: {{tickets[ticketId].Location}} </h3></div>
        <canvas id="barcode"></canvas>
      </b-modal>

    </div>
</template>

<script>
  export default {
      name: "Tickets",

      data() {
          return {
            tickets: [
              {
                TicketId:1,
                EventName: 'Show must go on',
                Artist: 'Céline Dion',
                Date:'02-01-19',
                Location: 'Las Vegas',
                ClientId: 2
              }
            ],
            months: {
              1: "JAN",
              2: "FÉV",
              3: "MAR",
              4: "AVR",
              5: "MAI",
              6: "JUN",
              7: "JUL",
              8: "AOÛ",
              9: "SEP",
              10: "OCT",
              11: "NOV",
              12: "DÉC",
            },
            ticketId: 0,
            barcodeValue: '123445435',
          }
      },

      methods:
        {
          OpenModal(index)
          {
            this.ticketId = index;
          },
          getTickets ()
          {

            this.$http.get('https://localhost:5001/api/ticket', {
				headers: {
					Authorization: "Bearer " + localStorage.getItem("token")
				}
			}
			).then(response => {
			  console.log(response.data[0]);
			  console.log(this.tickets[0]);
			  this.tickets = response.data;
			  //this.tickets.push(response.data[0]);
			  /*response.data.forEach(function(ticket) {
				  this.tickets.push(response.data[0])
				});*/
			  
            }, response => {
              // error callback
              console.log(response);
            });
          },
          getDay(date)
          {
            return date.split("-")[0];
          },
          getMonth(date)
          {
            return this.months[ parseInt(date.split("-")[1],10)];
          }
        },
      beforeMount(){
        this.getTickets();
      },
    }
</script>

<style scoped>
  .show{
    height: 150px;
    width: 1000px;
    padding: 0px;
    margin-bottom: 20px;
  }
  .show-date{
    width: 20%;
    height: 100%;
    float: left;
    background-color: aquamarine;
  }

  .day{
    margin:0;
    position:relative;
    height: 70%;
    color: black;
    font-size: 70px;
  }

  .month{
    top: 70%;
    font-size: 30px;
    font-weight: bold;
  }

  .show-info{
    width:80%;
    float: right;
    height:100%;
  }

  .show-name{
    font-size: 50px;
    position: relative;
    top:25%;
  }

  h1{
    color: #3eb8a1
  }
</style>
