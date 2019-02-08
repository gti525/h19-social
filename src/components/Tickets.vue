<template>
    <div  id="tickets">
	<h1 class="h1 mb-1 font-weight-normal">Mes billets:</h1>
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
        <svg width="455" height="210"><defs id="SvgjsDefs3933"></defs><g id="SvgjsG3934" featurekey="root" fill="#33f8df"></g><g id="SvgjsG3935" featurekey="symbol1" fill="#000000" transform="matrix(2.5092284202586637,0,0,2.5092284202586637,-13.376696335093008,-32.10379563851053)"><g xmlns="http://www.w3.org/2000/svg"><g><path fill="#000000" d="M57.039,15.584c0,0,17.664,22.829,3.072,43.271c-12.047,16.874,4.98,7.075,7.427,8.602    c2.444,1.524,2.051,4.588,4.195,5.287c2.142,0.7,4.772-0.606,7.307,0.483c2.533,1.087,4.578,3.795,8.627,3.475V15.584H57.039z     M70.163,61.508c0,0-0.154,1.574-1.539,1.525c-0.731-0.026-0.363-1.417-0.363-1.417s3.261-19.922-1.176-31.028    C67.085,30.588,73.875,41.802,70.163,61.508z M80.288,66.521c0,0-0.054,1.212-1.122,1.175c-0.562-0.021-0.34-1.091-0.34-1.091    s1.668-15.355-2.222-23.915C76.604,42.69,82.316,51.334,80.288,66.521z"></path><path fill="#000000" d="M12.663,15.584v61.118c4.051,0.32,6.094-2.388,8.628-3.475c2.536-1.09,5.163,0.217,7.307-0.483    c2.143-0.699,1.751-3.763,4.196-5.287c2.445-1.526,19.473,8.272,7.425-8.602c-14.592-20.442,3.07-43.271,3.07-43.271H12.663z     M33.249,30.588c-4.438,11.105-1.178,31.028-1.178,31.028s0.367,1.391-0.363,1.417c-1.384,0.049-1.541-1.525-1.541-1.525    C26.455,41.802,33.249,30.588,33.249,30.588z M23.727,42.69c-3.891,8.56-2.222,23.915-2.222,23.915s0.224,1.07-0.339,1.091    c-1.069,0.037-1.122-1.175-1.122-1.175C18.017,51.334,23.727,42.69,23.727,42.69z"></path></g><rect x="5.331" y="82.053" fill="#000000" width="89.669" height="3.354"></rect></g></g><g id="SvgjsG3936" featurekey="text1" fill="#000000" transform="matrix(10.149571987734282,0,0,10.149571987734282,258.9102553554515,-50.82264593253855)"><path d="M3.42 13.16 l0 6.84 l-2.82 0 l0 -14.5 l3.06 0 l1.58 6.12 l1.58 -6.12 l3.08 0 l0 14.5 l-2.82 0 l0 -6.84 l-1.84 5.8 z M16.54 20 l-3.06 0 l0 -3.68 l-2.78 -10.82 l3 0 l1.3 6.84 l1.32 -6.84 l3 0 l-2.78 10.82 l0 3.68 z"></path></g><g id="SvgjsG3937" featurekey="text2" fill="#000000" transform="matrix(2.9521441609408665,0,0,2.9521441609408665,263.22871519266596,145.76321274559336)"><path d="M0.6 5.5 l5.64 0 l0.5 2.7 l-3.16 0 l0 3.44 l2.4 0 l0 2.5 l-2.4 0 l0 3.16 l3.04 0 l-0.5 2.7 l-5.52 0 l0 -14.5 z M12.780000000000001 5.5 l2.94 0 l-2.68 14.5 l-3.02 0 l-2.68 -14.5 l2.94 0 l0.26 1.86 l0.98 7.5 l1 -7.54 z M16.52 5.5 l5.64 0 l0.5 2.7 l-3.16 0 l0 3.44 l2.4 0 l0 2.5 l-2.4 0 l0 3.16 l3.04 0 l-0.5 2.7 l-5.52 0 l0 -14.5 z M23.660000000000004 5.5 l2.76 0 l1.48 5.82 l0 -5.82 l2.98 0 l0 14.5 l-2.98 0 l-1.56 -6.06 l0 6.06 l-2.68 0 l0 -14.5 z M37.800000000000004 5.5 l0.72 2.7 l-1.94 0 l0 11.8 l-2.96 0 l0 -11.8 l-1.94 0 l0.76 -2.7 l5.36 0 z M42.50000000000001 8.04 q-0.26 0 -0.26 0.28 l0 8.84 q0 0.16 0.05 0.23 t0.23 0.07 l1.1 0 q0.18 0 0.23 -0.07 t0.05 -0.23 l0 -8.84 q0 -0.28 -0.26 -0.28 l-1.14 0 z M46.84 17.94 q0 0.42 -0.1 0.79 t-0.34 0.65 t-0.64 0.45 t-1 0.17 l-3.36 0 q-0.6 0 -1 -0.17 t-0.64 -0.45 t-0.34 -0.65 t-0.1 -0.79 l0 -10.56 q0 -0.86 0.47 -1.37 t1.49 -0.51 l3.6 0 q1.02 0 1.49 0.51 t0.47 1.37 l0 10.56 z M50.940000000000005 8.04 l0 5 l1.42 0 q0.28 0 0.28 -0.3 l0 -4.4 q0 -0.3 -0.28 -0.3 l-1.42 0 z M55.50000000000001 14.1 q0 0.48 -0.33 0.88 t-0.97 0.4 l1.52 4.62 l-3 0 l-1.4 -4.62 l-0.38 0 l0 4.62 l-2.9 0 l0 -14.5 l5.5 0 q1.02 0 1.49 0.51 t0.47 1.37 l0 6.72 z M62.18000000000001 20 l-3.06 0 l0 -3.68 l-2.78 -10.82 l3 0 l1.3 6.84 l1.32 -6.84 l3 0 l-2.78 10.82 l0 3.68 z"></path></g></svg>        <div> <h1>{{tickets[ticketId].EventName}} </h1></div>
        <div> <h2>{{tickets[ticketId].Artist}} </h2></div>
        <br/>
        <div> <h3>Date: {{tickets[ticketId].Date}} </h3></div>
        <div> <h3>Lieu: {{tickets[ticketId].Location}} </h3></div>
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

			  this.tickets = response.data;
			  
            }, response => {
              // error callback
              console.log(response);
            });
          },
          getDay(date)
          {
            return date.substring(8,10);
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
    background-color: 	#7cf9d6;
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
    color: #7cf9d6
  }
  
  .day, .month{
	color: #495057;
  }
  
  .show-date{
	border-style: solid;
	border-width: 0px 3px 0px 0px;
	border-color: #7fccb6;

  }
  
  .show-info {
	background-color: aquamarine;
   }
   
   .list-group-item {
		border-style: solid;
		border-width: 7px;
		border-color: #7fccb6;
	}
	
	.h1 {
	color: #42c6af;
  }
  
</style>
