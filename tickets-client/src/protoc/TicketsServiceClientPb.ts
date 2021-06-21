/**
 * @fileoverview gRPC-Web generated client stub for tickets
 * @enhanceable
 * @public
 */

// GENERATED CODE -- DO NOT EDIT!


/* eslint-disable */
// @ts-nocheck


import * as grpcWeb from 'grpc-web';

import * as tickets_pb from './tickets_pb';


export class TicketsClient {
  client_: grpcWeb.AbstractClientBase;
  hostname_: string;
  credentials_: null | { [index: string]: string; };
  options_: null | { [index: string]: any; };

  constructor (hostname: string,
               credentials?: null | { [index: string]: string; },
               options?: null | { [index: string]: any; }) {
    if (!options) options = {};
    if (!credentials) credentials = {};
    options['format'] = 'text';

    this.client_ = new grpcWeb.GrpcWebClientBase(options);
    this.hostname_ = hostname;
    this.credentials_ = credentials;
    this.options_ = options;
  }

  methodInfoGetTicket = new grpcWeb.AbstractClientBase.MethodInfo(
    tickets_pb.TicketReply,
    (request: tickets_pb.TicketRequestId) => {
      return request.serializeBinary();
    },
    tickets_pb.TicketReply.deserializeBinary
  );

  getTicket(
    request: tickets_pb.TicketRequestId,
    metadata: grpcWeb.Metadata | null): Promise<tickets_pb.TicketReply>;

  getTicket(
    request: tickets_pb.TicketRequestId,
    metadata: grpcWeb.Metadata | null,
    callback: (err: grpcWeb.Error,
               response: tickets_pb.TicketReply) => void): grpcWeb.ClientReadableStream<tickets_pb.TicketReply>;

  getTicket(
    request: tickets_pb.TicketRequestId,
    metadata: grpcWeb.Metadata | null,
    callback?: (err: grpcWeb.Error,
               response: tickets_pb.TicketReply) => void) {
    if (callback !== undefined) {
      return this.client_.rpcCall(
        this.hostname_ +
          '/tickets.Tickets/GetTicket',
        request,
        metadata || {},
        this.methodInfoGetTicket,
        callback);
    }
    return this.client_.unaryCall(
    this.hostname_ +
      '/tickets.Tickets/GetTicket',
    request,
    metadata || {},
    this.methodInfoGetTicket);
  }

  methodInfoGetAllTickets = new grpcWeb.AbstractClientBase.MethodInfo(
    tickets_pb.TicketsReply,
    (request: tickets_pb.AllTicketsRequest) => {
      return request.serializeBinary();
    },
    tickets_pb.TicketsReply.deserializeBinary
  );

  getAllTickets(
    request: tickets_pb.AllTicketsRequest,
    metadata: grpcWeb.Metadata | null): Promise<tickets_pb.TicketsReply>;

  getAllTickets(
    request: tickets_pb.AllTicketsRequest,
    metadata: grpcWeb.Metadata | null,
    callback: (err: grpcWeb.Error,
               response: tickets_pb.TicketsReply) => void): grpcWeb.ClientReadableStream<tickets_pb.TicketsReply>;

  getAllTickets(
    request: tickets_pb.AllTicketsRequest,
    metadata: grpcWeb.Metadata | null,
    callback?: (err: grpcWeb.Error,
               response: tickets_pb.TicketsReply) => void) {
    if (callback !== undefined) {
      return this.client_.rpcCall(
        this.hostname_ +
          '/tickets.Tickets/GetAllTickets',
        request,
        metadata || {},
        this.methodInfoGetAllTickets,
        callback);
    }
    return this.client_.unaryCall(
    this.hostname_ +
      '/tickets.Tickets/GetAllTickets',
    request,
    metadata || {},
    this.methodInfoGetAllTickets);
  }

  methodInfoAddTicket = new grpcWeb.AbstractClientBase.MethodInfo(
    tickets_pb.TicketReply,
    (request: tickets_pb.AddTicketRequest) => {
      return request.serializeBinary();
    },
    tickets_pb.TicketReply.deserializeBinary
  );

  addTicket(
    request: tickets_pb.AddTicketRequest,
    metadata: grpcWeb.Metadata | null): Promise<tickets_pb.TicketReply>;

  addTicket(
    request: tickets_pb.AddTicketRequest,
    metadata: grpcWeb.Metadata | null,
    callback: (err: grpcWeb.Error,
               response: tickets_pb.TicketReply) => void): grpcWeb.ClientReadableStream<tickets_pb.TicketReply>;

  addTicket(
    request: tickets_pb.AddTicketRequest,
    metadata: grpcWeb.Metadata | null,
    callback?: (err: grpcWeb.Error,
               response: tickets_pb.TicketReply) => void) {
    if (callback !== undefined) {
      return this.client_.rpcCall(
        this.hostname_ +
          '/tickets.Tickets/AddTicket',
        request,
        metadata || {},
        this.methodInfoAddTicket,
        callback);
    }
    return this.client_.unaryCall(
    this.hostname_ +
      '/tickets.Tickets/AddTicket',
    request,
    metadata || {},
    this.methodInfoAddTicket);
  }

  methodInfoDeleteTicket = new grpcWeb.AbstractClientBase.MethodInfo(
    tickets_pb.TicketRequestId,
    (request: tickets_pb.TicketRequestId) => {
      return request.serializeBinary();
    },
    tickets_pb.TicketRequestId.deserializeBinary
  );

  deleteTicket(
    request: tickets_pb.TicketRequestId,
    metadata: grpcWeb.Metadata | null): Promise<tickets_pb.TicketRequestId>;

  deleteTicket(
    request: tickets_pb.TicketRequestId,
    metadata: grpcWeb.Metadata | null,
    callback: (err: grpcWeb.Error,
               response: tickets_pb.TicketRequestId) => void): grpcWeb.ClientReadableStream<tickets_pb.TicketRequestId>;

  deleteTicket(
    request: tickets_pb.TicketRequestId,
    metadata: grpcWeb.Metadata | null,
    callback?: (err: grpcWeb.Error,
               response: tickets_pb.TicketRequestId) => void) {
    if (callback !== undefined) {
      return this.client_.rpcCall(
        this.hostname_ +
          '/tickets.Tickets/DeleteTicket',
        request,
        metadata || {},
        this.methodInfoDeleteTicket,
        callback);
    }
    return this.client_.unaryCall(
    this.hostname_ +
      '/tickets.Tickets/DeleteTicket',
    request,
    metadata || {},
    this.methodInfoDeleteTicket);
  }

  methodInfoEditTicket = new grpcWeb.AbstractClientBase.MethodInfo(
    tickets_pb.TicketReply,
    (request: tickets_pb.EditTicketRequest) => {
      return request.serializeBinary();
    },
    tickets_pb.TicketReply.deserializeBinary
  );

  editTicket(
    request: tickets_pb.EditTicketRequest,
    metadata: grpcWeb.Metadata | null): Promise<tickets_pb.TicketReply>;

  editTicket(
    request: tickets_pb.EditTicketRequest,
    metadata: grpcWeb.Metadata | null,
    callback: (err: grpcWeb.Error,
               response: tickets_pb.TicketReply) => void): grpcWeb.ClientReadableStream<tickets_pb.TicketReply>;

  editTicket(
    request: tickets_pb.EditTicketRequest,
    metadata: grpcWeb.Metadata | null,
    callback?: (err: grpcWeb.Error,
               response: tickets_pb.TicketReply) => void) {
    if (callback !== undefined) {
      return this.client_.rpcCall(
        this.hostname_ +
          '/tickets.Tickets/EditTicket',
        request,
        metadata || {},
        this.methodInfoEditTicket,
        callback);
    }
    return this.client_.unaryCall(
    this.hostname_ +
      '/tickets.Tickets/EditTicket',
    request,
    metadata || {},
    this.methodInfoEditTicket);
  }

}

